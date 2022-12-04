using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.DAL.dFramedbContext
{
    public partial class dFramedbContext : DbContext
    {
        public dFramedbContext()
        {
        }

        public dFramedbContext(DbContextOptions<dFramedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbl_WeightFactor> WeightFactors { get; set; }
    }
}