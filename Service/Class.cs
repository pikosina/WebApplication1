using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.Service.Core.Services.Base;

namespace WebApplication1.Service
{
    public interface IHashService
    {
     Task<int> AddHash(Hash hash);
     Task<int> DeleteHash(int id);

        List<Hash> SelectHashById(int id);
        List<Hash> GetHash();
    }

    public class NewsService : AsyncEntityService<Hash>, IHashService
    {
        public NewsService(DbContext context) : base(context) { }
        public Task<int> AddHash(Hash hash)
        {
            DbSet.Add(hash);
            Context.SaveChanges();
            return null;
        }
        public List<Hash> SelectHashById(int hash)
        {
            return DbSet.Where(x => x.Picture_Id == hash).ToList();
        }
        public Task<int> DeleteHash(int id)
        {
            var result = Dbset.Where(x => x.Id == id);
            Dbset.Remove(result.FirstOrDefault());
            Context.SaveChanges();
            return null;
        }
        public List<Hash> GetHash()
        {
            return DbSet.Where(x => x.Id != null).ToList();
        }
    }
}
