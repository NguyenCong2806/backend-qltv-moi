using WebEntryModel;
using WebEntryModel.EF;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class SachRepository : Repository<Sach>, ISachRepository
    {
        public SachRepository(AppDatabase appDatabase) : base(appDatabase)
        {
        }
    }
}