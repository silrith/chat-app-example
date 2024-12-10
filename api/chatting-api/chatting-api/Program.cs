namespace chatting_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSignalRDependencies();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors(builder => {
                builder
                    .WithOrigins("http://localhost:4444") // Vue uygulamanýzýn çalýþtýðý port
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
            app.UseSignalRDependencies();

            app.MapControllers();

            app.Run();
        }
    }
}
