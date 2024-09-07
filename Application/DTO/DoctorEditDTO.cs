namespace Application.DTO
{
    public class DoctorEditDTO
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Patronumic { get; set; } = null!;

        public string NameSpec { get; set; }

        public string NameSection { get; set; }
    }
}
