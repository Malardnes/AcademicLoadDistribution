using Ald.Dal.Context;
using Ald.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ald.Dal
{
    internal class GroupsRepository : Repository<Group>
    {
        public override IQueryable<Group> Items => base.Items
            .Include(g => g.Specialization)
            .ThenInclude(s => s.EducationPlans)
        ;

        public GroupsRepository(CollegeContext context) : base(context)
        {
        }
    }
}
