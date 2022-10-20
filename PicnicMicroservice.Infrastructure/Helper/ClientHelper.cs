using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;

namespace PicnicMicroservice.Infrastructure.Helper
{
    public class ClientHelper
    {
        public string? GetServerIP(HttpContext httpContext)
        {
            IHttpConnectionFeature? feature = httpContext.Features.Get<IHttpConnectionFeature>();
            return feature?.LocalIpAddress?.ToString();
        }

        public string GetCurrentUrl(HttpContext httpContext)
        {
            return UriHelper.GetDisplayUrl(httpContext.Request);
        }
    }
}
