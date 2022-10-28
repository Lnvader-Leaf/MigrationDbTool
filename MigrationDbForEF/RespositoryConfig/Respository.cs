using Microsoft.EntityFrameworkCore;
using MigrationDbForEF.IRespositoryConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MigrationDbForEF.RespositoryConfig
{
    public class Respository<T,TId> : IRespository<T,TId> where T : class
    {
        private readonly DbContext dbContext;

        public Respository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddEntityAsync(T t)
        {
            dbContext.Set<T>().AddAsync(t);
        }

        public void DeleteEntityAsync(T t)
        {
            dbContext.Set<T>().Remove(t);
        }

        public Task<IEnumerable<T>> GetEntityAsync()
        {
            var data = dbContext.Set<T>().AsEnumerable();
            return Task.FromResult(data);

        }

        public async Task<bool> SaveChangeAsync()
        {
            var execute = await dbContext.SaveChangesAsync();

            return execute > 0;
        }

        public void UpdateEntityAsync(T t)
        {
            dbContext.Set<T>().Update(t);
        }
    }
}
