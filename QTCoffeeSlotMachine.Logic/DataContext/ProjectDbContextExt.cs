using QTCoffeeSlotMachine.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCoffeeSlotMachine.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<Entities.SlotMachine>? SlotMachineSet { get; set; }
        public DbSet<Entities.Product>? ProducctSet { get; set; }
        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : IdentityEntity
        {
            if (typeof(E) == typeof(SlotMachine))
            {
                handled = true;
                dbSet = SlotMachineSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Product))
            {
                handled = true;
                dbSet = ProducctSet as DbSet<E>;
            }
        }
    }
}
