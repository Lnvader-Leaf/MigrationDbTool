using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.IService
{
    public interface IEFMigrationServices
    {
        public Task<bool> MigrationBaseInfo();
        public Task<bool> MigrationVisitInfo();
        public Task<bool> MigrationDiagInfo();
        public Task<bool> MigrationOrdersInfo();
        public Task<bool> MigrationLabInfo();
        public Task<bool> MigrationLabItemInfo();
        public Task<bool> MigrationExamInfo();
        public Task<bool> MigrationSignsInfo();
        public Task<bool> MigrationOperationInfo();
    }
}
