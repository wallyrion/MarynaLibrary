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
            _backupService = backupService;
        }


        [HttpPost]
        public async Task<OkResult> ImportFromMongoToSql()
        {
            await _backupService.BackUpFromMongoToSql();

            return Ok();
        }

        [HttpPost]
        public async Task<OkResult> ImportFromSqlToMongo()
        {
            await _backupService.BackUpFromSqlToMongo();

            return Ok();
        }
    }
}
