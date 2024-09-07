using DAL.Entity;
using DAL.Enums;

namespace DAL.Interfaces
{
    public interface IPacientStore
    {
        public Task<int> Add(Patient patient);
        public Task<int> Update(Patient patient);
        public Task<int> Delete(Patient patient);
        public List<Patient> Get(PacientSortOptions option);
        public Task<Patient> Get(int id);
        public bool IsExist(int id);
    }
}
