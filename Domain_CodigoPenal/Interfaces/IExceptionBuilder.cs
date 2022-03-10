using Domain_CodigoPenal.Services;
using System;
using System.Net;

namespace Domain_CodigoPenal.Interfaces
{
    public interface IExceptionBuilder
    {
        ExceptionBuilder Build(string message = null, bool log = true, Exception ex = null);
        ExceptionBuilder Build(int code, string message = null, bool log = true, Exception ex = null);
        ExceptionBuilder Build(HttpStatusCode code, string message = null, bool log = true, Exception ex = null);
    }
}
