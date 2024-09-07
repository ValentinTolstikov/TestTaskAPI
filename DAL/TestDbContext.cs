using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=172.18.0.2, 1433;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=BestPassword1@;Encrypt=False;Trust Server Certificate=True;Integrated Security=true;Trusted_Connection = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor);

            entity.HasOne(d => d.IdSectionNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.IdSection)
                .HasConstraintName("FK_Doctors_Sections");

            entity.HasOne(d => d.IdSpecNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.IdSpec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctors_Specializations");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient);

            entity.Property(e => e.Pol)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.IdSectionNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.IdSection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_Sections");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.IdSection);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.IdSpecification);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
