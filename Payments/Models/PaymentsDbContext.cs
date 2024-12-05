using Microsoft.EntityFrameworkCore;

namespace Payments.Models;

public class PaymentsDbContext : DbContext
{
    public DbSet<Purchase> Purchases { get; set; }
    
    public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) : base(options) { }
}