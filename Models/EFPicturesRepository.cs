using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EFPicturesRepository : IPictureRepository
    {
        private ApplicationDbContext context;
        public EFPicturesRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Picture> Pictures => context.Picture;  
    }
}
