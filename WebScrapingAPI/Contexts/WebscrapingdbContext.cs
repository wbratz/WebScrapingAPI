using Microsoft.EntityFrameworkCore;
using WebScrapingAPI.Contexts.Models;

namespace WebScrapingAPI.Contexts
{
    public partial class WebscrapingdbContext : DbContext
    {
        public WebscrapingdbContext()
        {
        }

        public WebscrapingdbContext(DbContextOptions<WebscrapingdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Subs> Subs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpVotes)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.SubId)
                    .HasConstraintName("FK_PostsSubId");
            });

            modelBuilder.Entity<Subs>(entity =>
            {
                entity.ToTable("Subs", "ref");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
