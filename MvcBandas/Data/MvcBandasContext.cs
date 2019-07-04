using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcBandas.Models;

namespace MvcBandas.Models
{   //Preparando el uso de Identity
    public class MvcBandasContext : IdentityDbContext<Usuario> //DbContext
    {
        public MvcBandasContext (DbContextOptions<MvcBandasContext> options)
            : base(options)
        {
        }
        public DbSet<MvcBandas.Models.Banda> Banda { get; set; }

        public DbSet<MvcBandas.Models.Concierto> Concierto { get; set; }
    }
}
