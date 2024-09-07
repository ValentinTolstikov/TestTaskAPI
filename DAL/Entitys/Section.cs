using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Entity;

public partial class Section
{
    public int IdSection { get; set; }

    public int Number { get; set; }

    [JsonIgnore]
    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    [JsonIgnore]
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
