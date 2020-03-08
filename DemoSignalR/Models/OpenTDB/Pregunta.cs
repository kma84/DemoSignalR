using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSignalR.Models.OpenTDB
{
	public class Pregunta
	{
		public string category { get; set; }
		public string type { get; set; }
		public string difficulty { get; set; }
		public string question { get; set; }
		public string correct_answer { get; set; }
		public List<string> incorrect_answers { get; set; }

		public override string ToString()
		{
			return $"Categoría: {category}. Tipo: {type}. Dificultad: {difficulty}. Pregunta: {question}";
		}
	}
}
