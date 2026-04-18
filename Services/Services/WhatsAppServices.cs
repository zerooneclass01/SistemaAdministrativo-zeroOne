using Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Services.Services
{
    public class WhatsAppServices : IWhatsAppServices
    {
        private readonly HttpClient _httpClient;

        public WhatsAppServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> EnviarMensagemAsync(string telefone, string mensagem)
        {
            
            var numeroLimpo = new string(telefone.Where(char.IsDigit).ToArray());

            
            var mensagemUrl = HttpUtility.UrlEncode(mensagem);

            
            var url = $"https://api.gatewaywhatsapp.com/send?number={numeroLimpo}&text={mensagemUrl}";

            var response = await _httpClient.PostAsync(url, null);
            return response.IsSuccessStatusCode ;
        }
    }
}
