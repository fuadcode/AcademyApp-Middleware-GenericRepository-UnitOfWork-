using AppAcademy.Core.Entities;
using AppAcademy.Core.Repositories;
using AppAcademy.Data.Data;

namespace AppAcademy.Data.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AcademyAppDbContext context) : base(context)
        {

        }
    }
}
