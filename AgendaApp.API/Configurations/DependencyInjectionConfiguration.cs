using AgendaApp.Domain.Interfaces.Messages;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Security;
using AgendaApp.Domain.Interfaces.Services;
using AgendaApp.Domain.Services;
using AgendaApp.Infra.Data.Repositories;
using AgendaApp.Infra.Messages.Producers;
using AgendaApp.Infra.Security.Services;

namespace AgendaApp.API.Configurations
{
    /// <summary>
    /// Classe de configuração para as injeções de dependência do projeto.
    /// </summary>
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IPessoaDomainService, PessoaDomainService>();
            services.AddTransient<ITarefaDomainService, TarefaDomainService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<IMessageProducer, MessageProducer>();
            services.AddTransient<ITokenSecurity, TokenSecurity>();
        }
    }
}



