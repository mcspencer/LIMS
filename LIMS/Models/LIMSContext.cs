using System.Data.Entity;

namespace LIMS.Models
{
    public class LIMSContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<LIMS.Models.LIMSContext>());

        public LIMSContext() : base("name=LIMSContext")
        {
        }

        public DbSet<Recording> Recordings { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectType> SubjectTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LabAsset>().
                HasMany(a => a.LabAssetTags).
                WithMany(t => t.LabAssets).
                Map(m => { 
                    m.MapLeftKey("LabAssetId"); 
                    m.MapRightKey("LabAssetTagId"); 
                    m.ToTable("AssetTags"); 
                });
        }
    }
}
