using AppAcademy.Core.Entities;
using AppAcademy.Core.Repositories;
using AppAcademy.Data.Data;

namespace AppAcademy.Data.Implementations
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AcademyAppDbContext context) : base(context)
        {

        }
    }
}
