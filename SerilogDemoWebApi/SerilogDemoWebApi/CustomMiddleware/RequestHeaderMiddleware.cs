using Newtonsoft.Json;

namespace SerilogDemoWebApi.CustomMiddleware
{
    public class RequestHeaderMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;
        public RequestHeaderMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var hasApiKey = context.Request.Headers.ContainsKey("CustomApiKey");
                if (hasApiKey)
                {
                    var incomingApiKey = context.Request.Headers["CustomApiKey"];
                    _logger.LogInformation($"API key Received in Header is : {incomingApiKey}");

                    context.Items["CustomApiKey"] = incomingApiKey;
                }
                else
                {
                    _logger.LogInformation("API key 'CustomApiKey' not found in Request Header");
                }
                await _next.Invoke(context);

            }
            catch (Exception)
            {
                throw new Exception("API key not found exception");
            }



        }
    }

}
