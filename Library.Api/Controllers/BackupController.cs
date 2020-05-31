using System.Threading.Tasks;
using Library.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BackupController : Controller
    {
        private readonly IBackupService _backupService;

        public BackupController(IBackupService backupService)
        {
            this._backupService = backupService;
        }


        [HttpPost]
        public async Task ImportFromMongoToSql()
        {
            await _backupService.BackUpFromMongoToSql();
        }

        [HttpPost]
        public async Task ImportFromSqlToMongo()
        {
            await _backupService.BackUpFromSqlToMongo();
        }
    }
}
