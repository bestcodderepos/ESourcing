using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContex : DbContext
    {
        public OrderContex(DbContextOptions<OrderContex> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
