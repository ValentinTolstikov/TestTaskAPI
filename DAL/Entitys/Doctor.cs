using System.Text.Json.Serialization;

namespace DAL.Entity;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronumic { get; set; } = null!;

    public int IdSpec { get; set; }

    public int IdSection { get; set; }

    [JsonIgnore]
    public virtual Section? IdSectionNavigation { get; set; }

    [JsonIgnore]
    public virtual Specialization IdSpecNavigation { get; set; } = null!;
}
