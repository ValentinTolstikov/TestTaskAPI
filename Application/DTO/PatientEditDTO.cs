namespace Application.DTO
{
    public class PatientEditDTO
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Patronumic { get; set; } = null!;

        public string Adres { get; set; } = null!;

        public DateOnly DateBorn { get; set; }

        public string Pol { get; set; } = null!;

        public string NameSection { get; set; }
    }
}
