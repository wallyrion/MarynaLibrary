using System.Linq;
using System.Threading.Tasks;
using Library.DAL.Dapper;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using Library.DAL.Mongo;

namespace Library.DAL.Services
{
    public class BackupRepository : IBackupRepository
    {
        private readonly IBookRepository _sqlBookRepository;
        private readonly IReaderRepository _sqlReaderRepository;
        private readonly ILibraryCardRepository _sqlLibraryCardRepository;

        private readonly BaseMongoRepository<Book> _mongoBookRepository;
        private readonly BaseMongoRepository<Reader> _mongoReaderRepository;
        private readonly BaseMongoRepository<LibraryCard> _mongoLibraryCardRepository;

        public BackupRepository(SqlContext sqlContext, MongoContext mongoContext)
        {
            _sqlBookRepository = new Dapper.Repositories.BookRepository(sqlContext);
            _sqlReaderRepository = new Dapper.Repositories.ReaderRepository(sqlContext);
            _sqlLibraryCardRepository = new Dapper.Repositories.LibraryCardRepository(sqlContext);

            _mongoBookRepository = new BaseMongoRepository<Book>(mongoContext);
            _mongoReaderRepository = new BaseMongoRepository<Reader>(mongoContext);
            _mongoLibraryCardRepository = new BaseMongoRepository<LibraryCard>(mongoContext);
        }

        public async Task ImportToSqlFromMongo()
        {
            var books = await _mongoBookRepository.GetAllAsync();
            var bookTasks = books.Select(b => _sqlBookRepository.CreateAsync(b));
            await Task.WhenAll(bookTasks);

            var readers = await _mongoReaderRepository.GetAllAsync();
            var readerTasks = readers.Select(r => _sqlReaderRepository.CreateAsync(r));
            await Task.WhenAll(readerTasks);

            var cards = await _mongoLibraryCardRepository.GetAllAsync();
            var cardsTasks = cards.Select(c => _sqlLibraryCardRepository.CreateAsync(c));
            await Task.WhenAll(cardsTasks);
        }

        public async Task ImportToMongoFromSql()
        {
            var books = await _sqlBookRepository.GetAllAsync();
            var bookTasks = books.Select(b => _mongoBookRepository.CreateAsync(b));
            await Task.WhenAll(bookTasks);

            var readers = await _sqlReaderRepository.GetAllAsync();
            var readerTasks = readers.Select(r => _mongoReaderRepository.CreateAsync(r));
            await Task.WhenAll(readerTasks);

            var cards = await _sqlLibraryCardRepository.GetAllAsync();
            var cardsTasks = cards.Select(c => _mongoLibraryCardRepository.CreateAsync(c));
            await Task.WhenAll(cardsTasks);
        }
    }
}
