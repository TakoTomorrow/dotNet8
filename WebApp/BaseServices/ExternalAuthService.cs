using LineAuthentication;

namespace WebApp.BaseServices;

public class ExternalAuthService
{
    /// <summary>
    /// 配置
    /// </summary>
    /// <param name="builder"></param>
    public static void Configure(WebApplicationBuilder builder)
    {
        // google External OAuth
        GoogleConfigure(builder);

        // line External OAuth
        LineConfigure(builder);
    }

    /// <summary>
    /// Google 認證
    /// </summary>
    /// <param name="builder">Wab Builder</param>
    private static void GoogleConfigure(WebApplicationBuilder builder)
    {
        var googleClientId = builder.Configuration["Authentication__Google__ClientId"] ?? throw new Exception("Google OpenId : ClientId is null.");
        var googleClientSecrect = builder.Configuration["Authentication__Google__ClientSecret"] ?? throw new Exception("Google OpenId : ClientSecret is null.");

        builder.Services.AddAuthentication().AddGoogle(googleOptions =>
        {
            googleOptions.ClientId = googleClientId;
            googleOptions.ClientSecret = googleClientSecrect;

            // Google Options 請見 https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.google.googleoptions?view=aspnetcore-8.0
        });
    }

    /// <summary>
    /// Line 認證
    /// </summary>
    /// <param name="builder">Wab Builder</param>
    private static void LineConfigure(WebApplicationBuilder builder)
    {
        var lineClientId = builder.Configuration["Authentication__Line__ClientId"] ?? throw new Exception("Line OpenId : ClientId is null.");
        var lineClientSecrect = builder.Configuration["Authentication__Line__ClientSecret"] ?? throw new Exception("Line OpenId : ClientSecret is null.");

        builder.Services.AddAuthentication().AddLine(lineOptions =>
        {
            lineOptions.ClientId = lineClientId;
            lineOptions.ClientSecret = lineClientSecrect;

            // Line Options 請見 https://developers.line.biz/en/docs/line-login/integrate-line-login/#making-an-authorization-request
        });
    }
}