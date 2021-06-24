using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;
using Microsoft.EntityFrameworkCore;

namespace dvdrental.Database.Repositories
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(DvdrentalContext context) : base(context)
        {
        }

        public Inventory GetInventory(int inventoryId)
        {
            return context.Inventories.Include(i => i.Film).FirstOrDefault(i => i.InventoryId == inventoryId);
        }
    }
}
