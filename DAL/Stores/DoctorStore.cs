using DAL.Entity;
using DAL.Enums;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Stores
{
    public class DoctorStore : IDoctorStore
    {
        private readonly TestDbContext _dbContext;

        public DoctorStore(TestDbContext context)
        { 
            _dbContext = context;
        }

        public Task<int> Add(Doctor doctor)
        {
            _dbContext.Doctors.AddAsync(doctor);
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> Delete(Doctor doctor)
        {
            _dbContext.Doctors.Remove(doctor);
            return _dbContext.SaveChangesAsync();
        }

        public List<Doctor> Get(DoctorSortOptions option)
        {
            switch (option)
            {

                case DoctorSortOptions.None:
                    List<Doctor> doctors = [.. _dbContext.Doctors];
                    return doctors;

                case DoctorSortOptions.Id:
                    return [.. _dbContext.Doctors.OrderBy(item => item.IdDoctor)];

                case DoctorSortOptions.Name:
                    return [.. _dbContext.Doctors.OrderBy(item => item.Name)];

                case DoctorSortOptions.Surname:
                    return [.. _dbContext.Doctors.OrderBy(item => item.Surname)];

                case DoctorSortOptions.Patronumic:
                    return [.. _dbContext.Doctors.OrderBy(item => item.Patronumic)];

                case DoctorSortOptions.IdSpec:
                    return [.. _dbContext.Doctors.OrderBy(item => item.IdSpec)];

                case DoctorSortOptions.IdSection:
                    return [.. _dbContext.Doctors.OrderBy(item => item.IdSection)];

                default:
                    throw new Exception("Чтото пошло не так");
            }
        }

        public Task<Doctor> Get(int id)
        {
            return _dbContext.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == id);
        }

        public bool IsExist(int id)
        {
            return _dbContext.Doctors.Find(id) != null;
        }

        public Task<int> Update(Doctor doctor)
        {
            _dbContext.Doctors.Update(doctor);
            return _dbContext.SaveChangesAsync();
        }
    }
}
