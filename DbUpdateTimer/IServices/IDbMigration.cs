using DbUpdateTimer.Mould;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbUpdateTimer.IServices
{
    public interface IDbMigration
    {
        public ResultMould Migration_View_Patient_Baseinfo(int currentTime);
    }
}
