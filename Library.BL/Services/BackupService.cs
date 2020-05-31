using System.Threading.Tasks;
using Library.BL.Interfaces;
using Library.DAL.Backup;

namespace Library.BL.Services
{
    public class BackupService : IBackupService
    {
        private readonly MongoBackupRepository _mongoBackupRepository;
        private readonly SqlBackupRepository _sqlBackupRepository;

        public BackupService(MongoBackupRepository mongoBackupRepository, SqlBackupRepository sqlBackupRepository)
        {
            _mongoBackupRepository = mongoBackupRepository;
            _sqlBackupRepository = sqlBackupRepository;
        }

        public async Task BackUpFromMongoToSql()
        {
            var data = await _mongoBackupRepository.Import();
            await _sqlBackupRepository.Export(data);
        }
        public async Task BackUpFromSqlToMongo()
        {
            var data = await _sqlBackupRepository.Import();
            await _mongoBackupRepository.Export(data);
        }

    }
}