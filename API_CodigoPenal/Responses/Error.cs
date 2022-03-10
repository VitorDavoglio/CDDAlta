using Domain_CodigoPenal.Services;
using System;
using System.Collections.Generic;
using System.Net;

namespace API_CodigoPenal.Responses
{
    public class Error
    {
        public Error(Exception ex)
        {
            if (ex is ExceptionBuilder)
            {
                var dic = new Dictionary<string, IEnumerable<string>>();
                dic.Add("apiError", new List<string>() { ex.Message });
                var e = ex as ExceptionBuilder;
                Errors = dic;
            }
            else
            {
                var dic = new Dictionary<string, IEnumerable<string>>();
                dic.Add("internalError", new List<string>() { ex.Message });
                Errors = dic;
            }
        }

        public Error(Dictionary<string, IEnumerable<string>> errors)
        {
            Errors = errors;
        }

        public static int GetStatusCode(Exception ex)
        {
            if (ex is ExceptionBuilder)
            {
                var e = ex as ExceptionBuilder;
                return (int)e.StatusCode;
            }
            else
            {
                return (int)HttpStatusCode.InternalServerError;
            }
        }

        public Dictionary<string, IEnumerable<string>> Errors { get; set; }
    }
}
