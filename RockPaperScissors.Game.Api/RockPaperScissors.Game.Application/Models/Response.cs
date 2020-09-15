using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RockPaperScissors.Game.Application.Models
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
