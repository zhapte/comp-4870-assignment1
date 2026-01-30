using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Article> Article { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ✅ Seed dummy Articles
        modelBuilder.Entity<Article>().HasData(

            new Article
            {
                ArticleId = 1,
                Headline = "BCIT Students Build Full-Stack Timesheet System",
                Author = "Kaid Krawchuk",
                DatePublished = new DateTime(2026, 1, 15),
                Content = "A group of BCIT students are developing a modern timesheet tracking system using ASP.NET Core and SQL Server."
            },

            new Article
            {
                ArticleId = 2,
                Headline = "2FA Authentication Added to Improve Security",
                Author = "Project Team",
                DatePublished = new DateTime(2026, 1, 20),
                Content = "The latest sprint introduced two-factor authentication to enhance account protection and role-based access."
            },

            new Article
            {
                ArticleId = 3,
                Headline = "OpenShift Deployment Becomes Key Focus for COMP4911",
                Author = "BCIT Computing Department",
                DatePublished = new DateTime(2026, 1, 25),
                Content = "Students are learning container deployment strategies using OpenShift and enterprise infrastructure."
            }
        );
    }

}
