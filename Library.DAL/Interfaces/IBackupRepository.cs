using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBackupRepository
    {
        Task ImportToSqlFromMongo();

        Task ImportToMongoFromSql();
    }
}