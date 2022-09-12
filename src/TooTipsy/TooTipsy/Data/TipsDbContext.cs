using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TooTipsy.Features.Calculations.Models;

namespace TooTipsy.Data;

public class TipsDbContext : IdentityDbContext
{
    public TipsDbContext(DbContextOptions<TipsDbContext> options)
        : base(options)
    {
    }
    public DbSet<Calculation> Calculations { get; set; } = default!;
}

