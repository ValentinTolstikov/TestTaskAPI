using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Stores
{
    public class SectionStore : ISectionStore
    {
        private readonly TestDbContext _dbContext;

        public SectionStore(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Section> GetSection(int id)
        {
            return _dbContext.Sections.FindAsync(id).AsTask();
        }

        public bool IsExist(int id)
        {
            return _dbContext.Sections.Find(id) != null;
        }
    }
}
