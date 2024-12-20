namespace AgendaApp.UI.Settings
{
    /// <summary>
    /// Classe para mapear os endereços das APIs
    /// </summary>
    public class HttpClientSettings
    {
        /// <summary>
        /// URL base da API de agenda
        /// </summary>
        private readonly static string UrlBase = "http://localhost:5008/api";

        public readonly static string CriarPessoa = $"{UrlBase}/pessoas/criar";
        public readonly static string AutenticarPessoa = $"{UrlBase}/pessoas/autenticar";
        public readonly static string Tarefas = $"{UrlBase}/tarefas";
    }
}



