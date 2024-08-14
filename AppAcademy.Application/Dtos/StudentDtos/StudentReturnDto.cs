namespace AppAcademy.Application.Dtos.StudentDtos
{
    public class StudentReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
