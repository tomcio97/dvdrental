using System;
using System.Collections.Generic;
using System.Text;
using dvdrental.Entities;

namespace dvdrental.Domain.Interfaces.Repositories
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Staff GetStaff(int staffId);
    }
}
