using System.Threading.Tasks;

namespace Library.BL.Interfaces
{
    public interface IBackupService
    {
        Task BackUpFromMongoToSql();

        Task BackUpFromSqlToMongo();
    }
}