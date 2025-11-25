using System.Globalization;

namespace MeuLivroDeReceitas.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next) {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo(requestedCulture);

            CultureInfo.CurrentCulture = new CultureInfo(requestedCulture);
            CultureInfo.CurrentUICulture = new CultureInfo(requestedCulture);

            await _next(context);
        }
    }
}
