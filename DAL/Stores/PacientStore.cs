using DAL.Entity;
using DAL.Enums;
using DAL.Interfaces;

namespace DAL.Stores
{
    public class PacientStore(TestDbContext dbContext) : IPacientStore
    {
        private readonly TestDbContext _dbContext = dbContext;

        public Task<int> Add(Patient patient)
        {
            _dbContext.Patients.AddAsync(patient);
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> Delete(Patient patient)
        {
            _dbContext.Patients.Remove(patient);
            return _dbContext.SaveChangesAsync();
        }

        public List<Patient> Get(PacientSortOptions option)
        {
                switch (option)
                {

                    case PacientSortOptions.None:
                         List<Patient> patients = _dbContext.Patients.ToList();
                         return patients;

                    case PacientSortOptions.Id:
                        return _dbContext.Patients.OrderBy(item => item.IdPatient)
                        .ToList();

                    case PacientSortOptions.Name:
                        return _dbContext.Patients.OrderBy(item => item.Name)
                        .ToList();

                    case PacientSortOptions.Surname:
                        return _dbContext.Patients.OrderBy(item => item.Surname)
                        .ToList();

                    case PacientSortOptions.Patronumic:
                        return _dbContext.Patients.OrderBy(item => item.Patronumic)
                        .ToList();

                    case PacientSortOptions.Adres:
                        return _dbContext.Patients.OrderBy(item => item.Adres)
                        .ToList();

                    case PacientSortOptions.DateBorn:
                        return _dbContext.Patients.OrderBy(item => item.DateBorn)
                        .ToList();

                    case PacientSortOptions.Pol:
                        return _dbContext.Patients.OrderBy(item => item.Pol)
                        .ToList();

                    case PacientSortOptions.IdSection:
                        return _dbContext.Patients.OrderBy(item => item.IdSection)
                        .ToList();

                    default:
                        throw new Exception("Чтото пошло не так");
                }
        }

        public Task<Patient> Get(int id)
        {
            return _dbContext.Patients.FindAsync(id).AsTask();
        }

        public bool IsExist(int id)
        {
            return _dbContext.Patients.Find(id) != null;
        }

        public Task<int> Update(Patient patient)
        {
            _dbContext.Patients.Update(patient);
            return _dbContext.SaveChangesAsync();
        }
    }
}
