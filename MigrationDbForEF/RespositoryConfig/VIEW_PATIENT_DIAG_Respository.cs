using Microsoft.EntityFrameworkCore;
using MigrationDbForEF.IRespositoryConfig;
using MigrationDbForEF.OracleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.RespositoryConfig
{
    public class VIEW_PATIENT_DIAG_Respository : Respository<VIEW_PATIENT_DIAG,int>, IVIEW_PATIENT_DIAG
    {
        private readonly DbContext dbContext;


        public VIEW_PATIENT_DIAG_Respository(DbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
