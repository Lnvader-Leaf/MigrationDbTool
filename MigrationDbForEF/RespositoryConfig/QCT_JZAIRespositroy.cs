using Microsoft.EntityFrameworkCore;
using MigrationDbForEF.IRespositoryConfig;
using MigrationDbForEF.OracleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.RespositoryConfig
{
    public class QCT_JZAIRespositroy:Respository<JZMould,int>,IQCT_JZAIRespository
    {
        private readonly DbContext dbContext;

        public QCT_JZAIRespositroy(DbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
