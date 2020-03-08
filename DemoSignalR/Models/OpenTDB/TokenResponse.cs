using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSignalR.Models.OpenTDB
{
    public class TokenResponse : BaseResponse
    {
        public string token { get; set; }
        public string response_message { get; set; }
    }
}
