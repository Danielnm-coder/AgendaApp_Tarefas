using AgendaApp.Ui.Dtos;
using AgendaApp.UI.Dtos;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AgendaApp.UI.Services
{
    public class AuthService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        public AuthService(ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        /// <summary>
        /// Método para autenticar o usuário e gravar 
        /// os seus dados na local storage do navegador
        /// </summary>
        public async Task SignIn(AutenticarPessoaResponseDto dto)
        {
            await _localStorageService.SetItemAsync("usuario", dto);
            _navigationManager.NavigateTo("/consultar-tarefas", true);
        }

        /// <summary>
        /// Método para deslogar o usuário
        /// </summary>
        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync("usuario");
            _navigationManager.NavigateTo("/", true);
        }

        /// <summary>
        /// Método para retornar os dados do usuário autenticado
        /// </summary>
        public async Task<AutenticarPessoaResponseDto?> GetData()
        {
            return await _localStorageService.GetItemAsync
                <AutenticarPessoaResponseDto>("usuario");
        }

        /// <summary>
        /// Método para verificar se o usuário está autenticado
        /// </summary>
        public async Task<bool> IsLoggedIn()
        {
            var data = await GetData();
            return data != null && data.DataHoraExpiracao >= DateTime.Now;
        }

        /// <summary>
        /// Método para retornar apenas o TOKEN do usuário
        /// </summary>
        public async Task<string> GetAccessToken()
        {
            var data = await GetData();
            return data.Token;
        }
    }
}



  