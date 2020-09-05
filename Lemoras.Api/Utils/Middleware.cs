using System;
using System.Text;
using System.Threading.Tasks;
using Lemoras.Domain.Parts.Utils;
using Lemoras.Domain.Parts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lemoras.Api.Utils
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        private readonly IApplicationContext _context;

        public Middleware(RequestDelegate next, IApplicationContext context)
        {
            this._next = next;
            this._context = context;
        }

        public async Task Invoke(HttpContext context)
        {
            byte[] data = null;

            var userId = _context.UserId; 

            try
            {
                Console.WriteLine($"Start - {GetUserAndRequestInfo(userId, context)}");
                await _next(context);
            }
            catch (BusinessException ex)
            {
                data = GetContentBody(ex.Message);
                Console.WriteLine($"Ex:{ex.Message} - {GetUserAndRequestInfo(userId, context)}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            catch (Exception ex)
            {
                var firstExp = ex.GetBaseException();

                Console.WriteLine($"Ex:{ex.Message} - {GetUserAndRequestInfo(userId, context)}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            finally
            {
                Console.WriteLine($"Finish - {GetUserAndRequestInfo(userId, context)}");
            }

            if (data != null)
            {
                context.Response.ContentType = "application/json";
                context.Response.Body.Write(data, 0, data.Length);
            }
            await Task.CompletedTask;
        }

        private static string GetUserAndRequestInfo(long userId, HttpContext context)
        {
            return $"UserId: {userId} - Request: {context.Request.Method} {context.Request.Path}";
        }

        private static byte[] GetContentBody(object obj)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new LowercaseContractResolver();
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
    }
}