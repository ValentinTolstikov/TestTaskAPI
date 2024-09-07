namespace Application.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Patronumic { get; set; } = null!;

        public int IdSpec { get; set; }

        public int IdSection { get; set; }
    }
}
