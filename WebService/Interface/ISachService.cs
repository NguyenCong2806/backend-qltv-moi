using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;

namespace WebService.Interface
{
    public interface ISachService : IService<Sachvm, Sach>
    {
        Task<Resultreturn<Sachvm>> GetAllSach(SearchParameters searchParameters);
        Task<IList<Sachvm>> GetAllSearch(string name);
        Task<bool> AddSach(Sachvm model);
        Task<bool> UpdateSach(Sachvm model);
        Task<bool> DeleteSach(Guid id);
        Task<Sachvm> GetSach(Guid id);
    }
}