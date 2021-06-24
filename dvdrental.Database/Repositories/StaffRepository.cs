using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dvdrental.Domain.Interfaces.Repositories;
using dvdrental.Entities;

namespace dvdrental.Database.Repositories
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        public StaffRepository(DvdrentalContext context) : base(context)
        {
        }
        public Staff GetStaff(int staffId)
        {
            return context.staff.FirstOrDefault(s => s.StaffId == staffId);
        }
    }
}
