using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Application;
using Vectra.Avaliacao.Backend.Application.DTOs;

namespace Vectra.Avaliacao.Backend.Application.Interfaces

.Interfaces
{
    public interface IResponse
    {
        void AddErrorMessages(string message);
        Task<Response> GenerateResponse(HttpStatusCode statusCode = HttpStatusCode.OK, bool hasError = default, string message = default, object collection = default);
    }
}
