using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace DemoSignalR.Models.OpenTDB
{
    public class Pregunta
	{
		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("difficulty")]
		public string Difficulty { get; set; }

		[JsonProperty("question")]
		public string Question { get; set; }

		[JsonProperty("correct_answer")]
		public string CorrectAnswer { get; set; }

		[JsonProperty("incorrect_answers")]
		public List<string> IncorrectAnswers { get; set; }
        
        public string DecodeQuestion()
        {
            return HttpUtility.UrlDecode(Question);
        }
        
		public override string ToString()
		{
			return $"Categoría: {Category}. Tipo: {Type}. Dificultad: {Difficulty}. Pregunta: {Question}";
		}
	}
}
