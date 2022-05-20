using PlatformService.Dtos;
using System.Threading.Tasks;

namespace PlatformService.SyncDataServices.http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}