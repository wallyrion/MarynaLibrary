using Library.DAL.Mongo.Repositories;
using Library.DAL.Interfaces;
using Library.DAL.Mongo;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Registers
{
    public class MongoRegister : IRegister
    {
        public void Register(IServiceCollection services, Settings settings)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<ILibraryCardRepository, LibraryCardRepository>();
        }
    }
}