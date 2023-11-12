using FLuentAPI.Middlewares;

namespace FLuentAPI.ExtensionMiddlewares
{
    public static class MapControllerMiddleware
    {
        public static IApplicationBuilder ConfigureRedirectionMap(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestMiddleware>();
            return app;
        }
    }
}
