using Domain_CodigoPenal.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Domain_CodigoPenal.Services
{
    public class ExceptionBuilder : Exception, IExceptionBuilder
    {
        private readonly ILogger<ExceptionBuilder> _log;
        public HttpStatusCode StatusCode { get; set; }

        private ExceptionBuilder(HttpStatusCode code, string message = "Houve um problema ao executar operção", Exception inner = null) : base(message, inner)
        {
            StatusCode = code;
        }

        private ExceptionBuilder(string message = "Houve um problema ao executar operção", Exception inner = null) : base(message, inner)
        {
        }

        public ExceptionBuilder(ILogger<ExceptionBuilder> log)
        {
            _log = log;
        }


        public ExceptionBuilder Build(string message = null, bool log = true, Exception ex = null)
        {
            if (log)
            {
                _log.LogError(message, ex);
            }
            return new ExceptionBuilder(message, ex);
        }

        public ExceptionBuilder Build(int code, string message=null, bool log = true, Exception ex = null)
        {
            return Build((HttpStatusCode)code, message, log, ex);
        }

        public ExceptionBuilder Build(HttpStatusCode code, string message=null, bool log = true, Exception ex = null)
        {
            var friendlyMessage = "";
            switch (code)
            {
                case HttpStatusCode.BadRequest:
                    {
                        friendlyMessage = message ?? "O Corpo da requisição não pode ser processado.";
                        if (log)
                        {
                            _log.LogError(message, ex);
                        }
                        return new ExceptionBuilder(code, friendlyMessage, ex);
                    }
                case HttpStatusCode.NotFound:
                    {
                        friendlyMessage = message ?? "Página não encontrada.";
                        if (log)
                        {
                            _log.LogError(message, ex);
                        }
                        return new ExceptionBuilder(code, friendlyMessage, ex);
                    }
                case HttpStatusCode.Forbidden:
                    {
                        friendlyMessage = message ?? "Acesso Negado.";
                        if (log)
                        {
                            _log.LogError(message, ex);
                        }
                        return new ExceptionBuilder(code, friendlyMessage, ex);
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        friendlyMessage = message ?? "Não Autorizado.";
                        if (log)
                        {
                            _log.LogError(message, ex);
                        }
                        return new ExceptionBuilder(code, friendlyMessage, ex);
                    }
                default:
                    {
                        if (log)
                        {
                            _log.LogError(message, ex);
                        }
                        return new ExceptionBuilder(code, message, ex);
                    }
            }
        }
    }
}
