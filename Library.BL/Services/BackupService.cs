using System.Threading.Tasks;
using Library.BL.Interfaces;
using Library.DAL.Interfaces;
using Library.DAL.Services;

namespace Library.BL.Services
{
    public class BackupService : IBackupService
    {
        private readonly IBackupRepository _backupRepository;

        public BackupService(IBackupRepository backupRepository)
        {
            _backupRepository = backupRepository;
        }

        public async Task BackUpFromMongoToSql()
        {
            await _backupRepository.ImportToSqlFromMongo();
        }

        public async Task BackUpFromSqlToMongo()
        {
            await _backupRepository.ImportToMongoFromSql();
        }
    }
}