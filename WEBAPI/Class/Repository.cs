using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Class
{
    public class Repository<ClassBD> : Interface.IRepository<ClassBD> where ClassBD : Base
    {
        //private readonly GemeStoreContext _CON;
        //public Repository()
        //{
        //    _CON = new GemeStoreContext();
        //}
        public async Task<bool> CreateASync(ClassBD x)
        {
            try
            {
                await using (GemeStoreContext v = new GemeStoreContext())
                {
                    await v.Set<ClassBD>().AddAsync(x);
                    await v.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<ClassBD>> ReadAsync()
        {
            try
            {
                await using (GemeStoreContext v = new GemeStoreContext())
                {
                    
                    return await v.Set<ClassBD>().ToListAsync();
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Game>> ReadAsync(string i)
        {
            try
            {
                await using (GemeStoreContext v = new GemeStoreContext())
                {
                    var t = await v.StyleFoGames.Where(p => p.Name.Equals(i)).FirstOrDefaultAsync(); // получаю список id жанра
                    var y = await v.Keys.Where(p => p.Idsyle.Equals(t.Id)).ToListAsync(); // выбираю id игр этого жанра
                    //var s = v.Games.Include(p => y.FirstOrDefault()).Where(p => p.Id.Equals(y.i).ToListAsync();
                    List<Game> GF = new List<Game>();
                    foreach ( var ty in y)
                    {
                        GF.Add(v.Games.Where(p => p.Id.Equals(ty.Idgem)).FirstOrDefault());
                    }
                    return GF; 
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> UpdateAsync(ClassBD x)
        {
            try
            {
                await using (GemeStoreContext v = new GemeStoreContext())
                {
                    v.Set<ClassBD>().Update(x);
                    await v.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DelASync(ClassBD i)
        {
            try
            {
                await using (GemeStoreContext v = new GemeStoreContext())
                {
                    v.Remove(i);
                    await v.SaveChangesAsync();
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
