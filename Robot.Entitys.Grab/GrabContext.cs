namespace Robot.Entitys.Grab
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GrabContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<SearchTask> SearchTask { get; set; }
        public virtual DbSet<SearchData> SearchData { get; set; }
        public GrabContext()
            : base("name=Grab")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<GrabContext>(null);
        }
    }
}
