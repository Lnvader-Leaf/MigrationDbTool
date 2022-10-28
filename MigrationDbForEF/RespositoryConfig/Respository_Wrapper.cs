using MigrationDbForEF.EfDbContext;
using MigrationDbForEF.IRespositoryConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.RespositoryConfig
{
    public class Respository_Wrapper : IRespository_Wrapper
    {
        public Respository_Wrapper(OracleDbContext oracleDbContext)
        {
            this.oracleDbContext = oracleDbContext;
        }
        private readonly OracleDbContext oracleDbContext;

        public IVIEW_PATIENT_DIAG VIEW_PATIENT_DIAG => new VIEW_PATIENT_DIAG_Respository(oracleDbContext);

        public IQCT_JZAIRespository QCT_JZAI => new QCT_JZAIRespositroy(oracleDbContext);
    }
}
