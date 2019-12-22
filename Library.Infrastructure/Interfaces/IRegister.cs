using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Interfaces
{
    public interface IRegister
    {
        void Register(IServiceCollection services, Settings settings);
    }
}