namespace WebApp.BaseServices;

public class ExternalAuthService
{
    public static void Configure(WebApplicationBuilder builder)
    {
        // google External OAuth
        GoogleConfigure(builder);
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
}