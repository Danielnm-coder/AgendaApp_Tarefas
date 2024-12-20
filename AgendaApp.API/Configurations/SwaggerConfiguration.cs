using Microsoft.OpenApi.Models;

namespace AgendaApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para a geração da documentação do Swagger
    /// </summary>
    public class SwaggerConfiguration
    {
        /// <summary>
        /// Método para definir as configurações / preferências do Swagger
        /// </summary>
        public static void AddSwaggerConfiguration(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                // Definindo informações da API
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AgendaApp - API para controle de agenda de tarefas",
                    Description = "API desenvolvida pela COTI Informática (www.cotiinformatica.com.br) para gerenciamento de agenda.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("https://www.cotiinformatica.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                // Configurando esquema de autenticação JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT no formato: Bearer {seu token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        /// <summary>
        /// Método para executar e aplicar as configurações do Swagger
        /// </summary>
        public static void UseSwaggerConfiguration(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // Customizando o título e o tema do SwaggerUI
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendaApp API v1");
                c.DocumentTitle = "AgendaApp - Controle de Agenda";
            });
        }
    }
}



