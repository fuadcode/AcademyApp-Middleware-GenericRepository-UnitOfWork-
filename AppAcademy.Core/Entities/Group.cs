namespace AppAcademy.Core.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public int Limit { get; set; }
        public List<Student> Students { get; set; }
    }
}
