namespace Application.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Patronumic { get; set; } = null!;

        public string Adres { get; set; } = null!;

        public DateOnly DateBorn { get; set; }

        public string Pol { get; set; } = null!;

        public int IdSection { get; set; }
    }
}
