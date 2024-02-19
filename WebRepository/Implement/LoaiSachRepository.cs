using WebEntryModel;
using WebEntryModel.EF;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class LoaiSachRepository : Repository<LoaiSach>, ILoaiSachRepository
    {
        public LoaiSachRepository(AppDatabase appDatabase) : base(appDatabase)
        {
        }
    }
}