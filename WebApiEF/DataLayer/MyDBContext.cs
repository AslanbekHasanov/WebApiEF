using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.Models;

namespace WebApiEF.DataLayer
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        { }

        public DbSet<UserModel> UserModels { get; set; }
    }
}
