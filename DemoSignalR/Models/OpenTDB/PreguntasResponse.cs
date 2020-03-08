using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSignalR.Models.OpenTDB
{
    public class PreguntasResponse : BaseResponse
    {
        public List<Pregunta> results { get; set; }
    }
}
