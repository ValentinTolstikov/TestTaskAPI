using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entity;

public partial class Patient
{
    public int IdPatient { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronumic { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public DateOnly DateBorn { get; set; }

    public string Pol { get; set; } = null!;

    public int IdSection { get; set; }

    [JsonIgnore]
    public virtual Section IdSectionNavigation { get; set; } = null!;
}
