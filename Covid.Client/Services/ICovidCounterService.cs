using System.Threading.Tasks;
using Covid.Shared;

namespace Covid.Client.Services
{
    public interface ICovidCounterService
    {
        Task<AreaCounter> GetAreaCounterAsync(string area);
        Task<bool> PublishCounterAsync(AreaCounter areaCounter);
    }
}
