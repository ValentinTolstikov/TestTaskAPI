using DAL.Entity;
using DAL.Enums;

namespace DAL.Interfaces
{
    public interface IDoctorStore
    {
        public Task<int> Add(Doctor doctor);
        public Task<int> Update(Doctor doctor);
        public Task<int> Delete(Doctor doctor);
        public List<Doctor> Get(DoctorSortOptions option);
        public Task<Doctor> Get(int id);
        public bool IsExist(int id);
    }
}
