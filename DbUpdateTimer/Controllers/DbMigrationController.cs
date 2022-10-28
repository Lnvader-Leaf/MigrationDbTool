using DbUpdateTimer.IServices;
using DbUpdateTimer.Mould;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbUpdateTimer.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DbMigrationController : ControllerBase
    {
        private readonly IDbMigration _dbMigration;

        public DbMigrationController(IDbMigration dbMigration)
        {
            _dbMigration = dbMigration;
        }
        [HttpGet]
        public ActionResult<ResultMould> Migration_View_Patient_Baseinfo()
        {
            return _dbMigration.Migration_View_Patient_Baseinfo(1);
        }
    }
}
