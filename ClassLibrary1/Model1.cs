namespace ClassLibrary1
{
    using System.Data.Entity;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<integraDUExcel> integraDUExcel { get; set; }
        public virtual DbSet<integraDUStages> integraDUStages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<integraDUExcel>()
                .Property(e => e.SysStartTime)
                .HasPrecision(0);

            modelBuilder.Entity<integraDUExcel>()
                .Property(e => e.SysEndTime)
                .HasPrecision(0);

            modelBuilder.Entity<integraDUStages>()
                .Property(e => e.SysStartTime)
                .HasPrecision(0);

            modelBuilder.Entity<integraDUStages>()
                .Property(e => e.SysEndTime)
                .HasPrecision(0);

            modelBuilder.Entity<integraDUStages>()
                .HasOptional(e => e.integraDUExcel)
                .WithRequired(e => e.integraDUStages)
                .WillCascadeOnDelete();
        }
    }
}
