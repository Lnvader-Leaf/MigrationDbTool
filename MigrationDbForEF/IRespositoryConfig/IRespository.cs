using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MigrationDbForEF.IRespositoryConfig
{
    public interface IRespository<T,TId>
    {
        public void AddEntityAsync(T t);
        public void DeleteEntityAsync(T t);
        public void UpdateEntityAsync(T t);
        public Task<IEnumerable<T>> GetEntityAsync();
        public Task<bool> SaveChangeAsync();
    }
}
