using AgendaApp.UI.Services;

namespace AgendaApp.UI.Interceptors
{
    public class AuthInterceptor : DelegatingHandler
    {
        private readonly AuthService _authService;

        public AuthInterceptor(AuthService authService)
        {
            _authService = authService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //capturando o tokend o usuário autenticado
            var token = await _authService.GetAccessToken();

            //adicionar o token na requisição da API
            request.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}



