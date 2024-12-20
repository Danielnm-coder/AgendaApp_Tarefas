namespace AgendaApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração da política de CORS da API
    /// </summary>
    public class CorsConfiguration
    {
        public static void AddCorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AgendaPolicy", builder =>
                {
                    builder.WithOrigins(
                                "http://localhost:4200", //ANGULAR
                                "http://localhost:5056" //BLAZOR
                            )
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public static void UseCorsConfiguration(IApplicationBuilder app)
        {
            app.UseCors("AgendaPolicy");
        }
    }
}



