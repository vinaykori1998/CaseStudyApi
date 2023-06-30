using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaseStudyApi.Models;

namespace CaseStudyApi.Data
{
    public class CaseStudyApiContext : DbContext
    {
        public CaseStudyApiContext (DbContextOptions<CaseStudyApiContext> options)
            : base(options)
        {
        }

        public DbSet<CaseStudyApi.Models.Product> Product { get; set; } = default!;

        public DbSet<CaseStudyApi.Models.Seller> Seller { get; set; }

        public DbSet<CaseStudyApi.Models.Customer> Customer { get; set; }

        public DbSet<CaseStudyApi.Models.Order> Order { get; set; }
    }
}
