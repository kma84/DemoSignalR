using DemoSignalR.Models.OpenTDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoSignalR.Services
{
    public class PreguntasService
    {
        private readonly HttpClient httpClient = new HttpClient();

		private readonly string preguntasPath = "https://opentdb.com/api.php?amount=10&difficulty=easy&type=multiple&token={0}";
		private readonly string tokenPath = "https://opentdb.com/api_token.php?command=request";
		private readonly string resetPath = "https://opentdb.com/api_token.php?command=reset&token={0}";
		private readonly int TOKEN_EMPTY = 4;

		private List<Pregunta> Preguntas { get; set; } = new List<Pregunta>();
		private string Token { get; set; }


		//public PreguntasService()
		//{
		//	var pregunta = SiguientePregunta().GetAwaiter().GetResult();

		//	Console.WriteLine(pregunta);
		//}


		public async Task<Pregunta> SiguientePregunta()
		{
			if (!Preguntas.Any())
			{
				Preguntas.AddRange(await GetPreguntasAsync());
			}

			return Preguntas.FirstOrDefault();
		}


		private async Task<List<Pregunta>> GetPreguntasAsync()
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				TokenResponse tokenResponse = await GetResponse<TokenResponse>(tokenPath);
				Token = tokenResponse.token;
			}

			PreguntasResponse preguntasResponse = await GetResponse<PreguntasResponse>(string.Format(preguntasPath, Token));

			if (preguntasResponse.response_code == TOKEN_EMPTY)
			{
				TokenResponse tokenResetResponse = await GetResponse<TokenResponse>(string.Format(resetPath, Token));
				Token = tokenResetResponse.token;

				preguntasResponse = await GetResponse<PreguntasResponse>(string.Format(preguntasPath, Token));
			}

			return preguntasResponse.results;
		}


		private async Task<T> GetResponse<T>(string path) where T : BaseResponse
		{
			T openTDBResponse = null;
			HttpResponseMessage response = await httpClient.GetAsync(path);

			if (response.IsSuccessStatusCode)
			{
				openTDBResponse = await response.Content.ReadAsAsync<T>();
			}

			return openTDBResponse;
		}

	}
}
