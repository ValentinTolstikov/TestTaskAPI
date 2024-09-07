using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Stores
{
    public class SpecializationStore : ISpecializationStore
    {
        private readonly TestDbContext _dbContext;

        public SpecializationStore(TestDbContext context) 
        {
            _dbContext = context;
        }

        public Task<Specialization> GetSpecialization(int id)
        {
            return _dbContext.Specializations.FindAsync(id).AsTask();
        }

        public bool IsExist(int id)
        {
            return _dbContext.Specializations.Find(id) != null;
        }
    }
}
