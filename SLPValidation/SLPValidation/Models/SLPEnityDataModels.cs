namespace SLPValidation.Models
{
    using System.Data.Entity;

    public partial class SLPEnityDataModels : DbContext
    {
        public SLPEnityDataModels()
            : base("name=SLPEnityDataModels")
        {
        }

        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<SLPRequestRecords> SLPRequestRecords { get; set; }
        public virtual DbSet<ValidationResult> ValidationResult { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}
