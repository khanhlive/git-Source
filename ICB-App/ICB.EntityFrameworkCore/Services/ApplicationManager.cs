using NDK.ApplicationCore.EFGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICB.EntityFrameworkCore.Services
{
    public class ApplicationManager<T, KeyType> : EntityFrameworkRepository<T, KeyType> where T : class
    {
        public ApplicationManager() : base(new ICB.EntityFrameworkCore.Models.ICB_DbContext())
        {

        }
    }
}
