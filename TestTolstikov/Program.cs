using Application.Services;
using DAL;
using DAL.Interfaces;
using DAL.Stores;

namespace TestTolstikov
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TestDbContext>();

            builder.Services.AddScoped<ISectionStore,SectionStore>();
            builder.Services.AddScoped<ISpecializationStore, SpecializationStore>();
            builder.Services.AddScoped<IDoctorStore, DoctorStore>();
            builder.Services.AddScoped<IPacientStore, PacientStore>();

            builder.Services.AddScoped<DoctorService, DoctorService>();
            builder.Services.AddScoped<PatientService, PatientService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
