using System;
using System.IO;
using Lemoras.Domain.Parts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Lemoras.Api.Utils
{
    public class ApplicationContext: IApplicationContext
    {
        protected readonly IHttpContextAccessor _contextAccessor;

        public ApplicationContext(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;            
        }

        public int UserId
        {
            get { return !string.IsNullOrWhiteSpace(_contextAccessor.HttpContext.Request.Headers["UserId"].ToString()) ? int.Parse(_contextAccessor.HttpContext.Request.Headers["UserId"]) : 0; }
        }

        public string Token
        {
            get { return  _contextAccessor.HttpContext.Request.Headers["Token"]; }
        }

        public SecurityType SecurityType
        {
            get { return  SecurityType.Admin; }
        }
    }

    public class ApplicationContext<TContract> : ApplicationContext, IApplicationContext<TContract> where TContract : class
    {
        private readonly TContract _contract;

        public ApplicationContext(IHttpContextAccessor contextAccessor)
            : base (contextAccessor)
        {
            if (_contextAccessor.HttpContext.Request.Method == System.Net.WebRequestMethods.Http.Post)
            {
                StreamReader reader = new StreamReader(base._contextAccessor.HttpContext.Request.Body);
            
                var body = reader.ReadToEndAsync().Result;

                if (string.IsNullOrEmpty(body))
                    throw new Exception("HttpPost Body is null or empty!");

                    

                _contract =  JsonConvert.DeserializeObject<TContract>(body);
            }
        }

        public TContract Contract
        {
            get { return _contract; }
        }
    }
}
