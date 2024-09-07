using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Entity;

public partial class Specialization
{
    public int IdSpecification { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
