using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsightFlow.Documents.Api.Core.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public List<string> Errors { get; set; }


        public ApiResponse()
        {
            Success = true;
            Message = string.Empty;
            Errors = new List<string>();
        }

        public ApiResponse(string Message)
        {
            Success = false;
            this.Message = Message;
            Errors = new List<string>();
        }  
    } 
}