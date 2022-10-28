using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.AutoMapperConfig
{
    public class ServerProFile : Profile
    {
        public ServerProFile()
        {
            CreateMap<SqlServerEntity.VIEW_PATIENT_BASEINFO, OracleEntity.VIEW_PATIENT_BASEINFO>().ForMember(m => m.CTIME, n => n.NullSubstitute(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))).ForMember(m => m.STATE, n => n.NullSubstitute("0"));
            CreateMap<SqlServerEntity.VIEW_PATIENT_DIAG, OracleEntity.VIEW_PATIENT_DIAG>().ForMember(m => m.CTIME, n => n.NullSubstitute(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))).ForMember(m => m.STATE, n => n.NullSubstitute("0"));
            CreateMap<SqlServerEntity.VIEW_PATIENT_VISITINFO, OracleEntity.VIEW_PATIENT_VISITINFO>().ForMember(m => m.CTIME, n => n.NullSubstitute(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))).ForMember(m => m.STATE, n => n.NullSubstitute("0"));
        }
    }
}
