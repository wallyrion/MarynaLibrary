using Library.DAL.Dapper;
using Library.DAL.Dapper.Repositories;
using Library.DAL.Interfaces;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Registers
{
    public class SqlRegister : IRegister
    {
        public void Register(IServiceCollection services, Settings settings)
        {
            services.AddScoped(options => new Context(settings.ConnectionString));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<ILibraryCardRepository, LibraryCardRepository>();
        }
    }
}