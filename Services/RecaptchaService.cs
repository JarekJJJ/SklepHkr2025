using Microsoft.JSInterop;

namespace SklepHkr2025.Services
{
    public class RecaptchaService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly string _siteKey;

        public RecaptchaService(IJSRuntime jsRuntime, IConfiguration configuration)
        {
            _jsRuntime = jsRuntime;
            _siteKey = configuration["GoogleReCaptcha:SiteKey"]!;
        }

        public async Task<string?> GetTokenAsync(string action = "submit")
        {
            return await _jsRuntime.InvokeAsync<string>(
                "grecaptcha.execute",
                _siteKey,
                new { action }
            );
        }
    }
}
