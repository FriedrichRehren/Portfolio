namespace Portfolio.Backend.Data;

using Microsoft.EntityFrameworkCore;
using Portfolio.Backend.Models;

public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Domain> Domains { get; set; }
}