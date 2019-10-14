using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Services.Responses.Contracts
{
    public abstract class AbstractResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public AbstractResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
