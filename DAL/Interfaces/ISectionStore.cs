using DAL.Entity;

namespace DAL.Interfaces
{
    public interface ISectionStore
    {
        public Task<Section> GetSection(int id);
        public bool IsExist(int id);
    }
}
