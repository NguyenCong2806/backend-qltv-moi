using WebEntryModel;
using WebEntryModel.EF;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class PhieuTraRepsitory : Repository<PhieuTra>, IPhieuTraRepsitory
    {
        public PhieuTraRepsitory(AppDatabase appDatabase) : base(appDatabase)
        {
        }
    }
}