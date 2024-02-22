using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;

namespace WebService.Interface
{
    public interface IPhieuTraService : IService<PhieuTravm, PhieuTra>
    {
        Task<Resultreturn<PhieuTravm>> GetAllPhieuTra(SearchParameters searchParameters);
        Task<bool> AddPhieuTra(PhieuTravm model);
        Task<bool> UpdatePhieuTra(PhieuTravm model);
        Task<bool> DeletePhieuTra(Guid id);
        Task<PhieuTravm> GetPhieuTra(Guid id);
    }
}