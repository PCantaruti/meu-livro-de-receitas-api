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
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var header = context.Request.Headers["Accept-Language"].ToString();
            var requestedCulture = header?.Split(',').FirstOrDefault()?.Split(';').FirstOrDefault();

            var cultureInfo = new CultureInfo("en");

            if(string.IsNullOrWhiteSpace(requestedCulture) == false 
                && supportedLanguages.Any(c => c.Name.Equals(requestedCulture)))
            {
                cultureInfo = new CultureInfo(requestedCulture);
            }

            CultureInfo.CurrentCulture = new CultureInfo(requestedCulture);
            CultureInfo.CurrentUICulture = new CultureInfo(requestedCulture);

            await _next(context);
        }
    }
}
