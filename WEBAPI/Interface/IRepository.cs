using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Interface
{
    public interface IRepository<ClassBD> where ClassBD : Base
    {
        public Task<bool> CreateASync(ClassBD x);
        public Task<List<ClassBD>> ReadAsync();
        public Task<List<Game>> ReadAsync(string i);
        public Task<bool> UpdateAsync(ClassBD x);
        public Task<bool> DelASync(ClassBD i);
    }
}
