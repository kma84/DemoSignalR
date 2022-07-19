using DemoSignalR.Models.OpenTDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoSignalR.Services
{
    public class PreguntasService : IDisposable
    {
        private readonly HttpClient httpClient = new HttpClient();

		private readonly string preguntasPath = "https://opentdb.com/api.php?amount=10&difficulty=easy&type=multiple&token={0}";
		private readonly string tokenPath = "https://opentdb.com/api_token.php?command=request";
		private readonly string resetPath = "https://opentdb.com/api_token.php?command=reset&token={0}";
		private readonly int TOKEN_EMPTY = 4;

        private List<(Pregunta pregunta, List<string> enviadaA)> Preguntas { get; set; } = new List<(Pregunta, List<string>)>();
        private string Token { get; set; }


		public async Task<Pregunta> SiguientePregunta(string userId)
		{
			if (Preguntas.All(p => p.enviadaA.Contains(userId)))
			{
				Preguntas.AddRange( (await GetPreguntasAsync()).Select( p => (p, new List<string>()) ) );
			}

            (var siguientePregunta, var enviadaA) = Preguntas.FirstOrDefault(p => !p.enviadaA.Contains(userId));
            enviadaA.Add(userId);

            return siguientePregunta;
		}


		private async Task<List<Pregunta>> GetPreguntasAsync()
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				TokenResponse tokenResponse = await GetResponse<TokenResponse>(tokenPath);
				Token = tokenResponse.Token;
			}

			PreguntasResponse preguntasResponse = await GetResponse<PreguntasResponse>(string.Format(CultureInfo.InvariantCulture, preguntasPath, Token));

			if (preguntasResponse.ResponseCode == TOKEN_EMPTY)
			{
				TokenResponse tokenResetResponse = await GetResponse<TokenResponse>(string.Format(CultureInfo.InvariantCulture, resetPath, Token));
				Token = tokenResetResponse.Token;

				preguntasResponse = await GetResponse<PreguntasResponse>(string.Format(CultureInfo.InvariantCulture, preguntasPath, Token));
			}

			return preguntasResponse.Results;
		}


		private async Task<T> GetResponse<T>(string path) where T : BaseResponse
		{
			T openTDBResponse = null;
			HttpResponseMessage response = await httpClient.GetAsync(path);

			if (response.IsSuccessStatusCode)
			{
				openTDBResponse = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
			}

			return openTDBResponse;
		}

        public void Dispose()
        {
			GC.SuppressFinalize(this);
            httpClient.Dispose();
        }
    }
}
