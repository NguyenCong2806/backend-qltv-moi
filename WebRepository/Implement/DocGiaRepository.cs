using WebEntryModel;
using WebEntryModel.EF;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class DocGiaRepository : Repository<DocGia>, IDocGiaRepository
    {
        public DocGiaRepository(AppDatabase appDatabase) : base(appDatabase)
        {
        }
    }
}