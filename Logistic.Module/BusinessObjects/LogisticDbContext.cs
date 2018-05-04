using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Logistic.Module.BusinessObjects
{
    public class LogisticDbContext : DbContext
    {
        public LogisticDbContext()
            : base("name=ConnectionString")
        {
        }
        public LogisticDbContext(String connectionString)
            : base(connectionString)
        {
        }
        public LogisticDbContext(DbConnection connection)
            : base(connection, false)
        {
        }

        public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
        public DbSet<ModelDifference> ModelDifferences { get; set; }
        public DbSet<ModuleInfo> ModulesInfo { get; set; }

    }
}