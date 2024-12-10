namespace Microsoft.Extensions.DependencyInjection;

public static class SignalRSetupExtensions
{
    public static void AddSignalRDependencies(this IServiceCollection services)
    {
        services.AddSignalR();
    }

    public static void UseSignalRDependencies(this IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<ChatHub>("/silrith-hub");
        });
    }
}
