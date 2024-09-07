using DAL.Entity;

namespace DAL.Interfaces
{
    public interface ISpecializationStore
    {
        public Task<Specialization> GetSpecialization(int id);
        public bool IsExist(int id);
    }
}
