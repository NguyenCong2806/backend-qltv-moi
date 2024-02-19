using WebEntryModel;
using WebEntryModel.EF;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class NhaXuatBanRepository : Repository<NhaXuatBan>, INhaXuatBanRepository
    {
        public NhaXuatBanRepository(AppDatabase appDatabase) : base(appDatabase)
        {
        }
    }
}