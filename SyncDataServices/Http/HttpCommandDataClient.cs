using System.Text;
using System.Text.Json;
using PlatformService.Dtos;


namespace PlatformService.SyncDataServices.http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
              JsonSerializer.Serialize(plat),
              Encoding.UTF8,
              "application/json");
            
            var respone = await _httpClient.PostAsync($"{_config["CommandService"]}", httpContent);

            if(respone.IsSuccessStatusCode){
                Console.WriteLine("--> sync post to commandService was OK!");
            }
            else{
                Console.WriteLine("--> sync post was not ok");
            }

        }
    }
}