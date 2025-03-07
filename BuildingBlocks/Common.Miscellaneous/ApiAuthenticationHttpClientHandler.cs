using AngleSharp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Common.Miscellaneous
{

 public sealed class ApiAuthenticationHttpClientHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _accessor;

    public ApiAuthenticationHttpClientHandler(IHttpContextAccessor accessor)
    {
        _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_accessor.HttpContext == null)
        {
            throw new ArgumentNullException(nameof(_accessor.HttpContext));
        }

        var token = await _accessor.HttpContext.GetTokenAsync("access_token");
        var subProgramCode = _accessor.HttpContext.Request.Headers["subprogramcode"].ToString();

        // Use the token to make the call.
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Headers.Add("subprogramcode", subProgramCode);

        return await base.SendAsync(request, cancellationToken);
    }
}

}
