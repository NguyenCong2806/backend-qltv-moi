using WebEntryModel;
using WebEntryModel.EF;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class ChiTietPhieuMuonRepository: Repository<ChiTietPhieuMuon>,IChiTietPhieuMuonRepository
    {
        public ChiTietPhieuMuonRepository(AppDatabase appDatabase) : base(appDatabase)
        {
        }
    }
}