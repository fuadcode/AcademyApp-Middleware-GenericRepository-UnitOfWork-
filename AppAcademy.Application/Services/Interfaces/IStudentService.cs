using AppAcademy.Application.Dtos.StudentDtos;

namespace AppAcademy.Application.Services.Interfaces
{
    public interface IStudentService
    {
        int Create(StudentCreateDto studentCreateDto);
        List<StudentReturnDto> GetAll();
    }
}
