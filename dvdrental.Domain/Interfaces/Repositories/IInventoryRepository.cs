using System;
using System.Collections.Generic;
using System.Text;
using dvdrental.Entities;

namespace dvdrental.Domain.Interfaces.Repositories
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        Inventory GetInventory(int inventoryId);
    }
}
