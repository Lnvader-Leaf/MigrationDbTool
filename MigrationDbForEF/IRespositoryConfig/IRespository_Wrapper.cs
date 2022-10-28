using MigrationDbForEF.RespositoryConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.IRespositoryConfig
{
    public interface IRespository_Wrapper
    {
        IVIEW_PATIENT_DIAG VIEW_PATIENT_DIAG { get; }
        IQCT_JZAIRespository QCT_JZAI { get; }
    }
}
