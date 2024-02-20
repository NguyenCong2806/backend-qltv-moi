using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;

namespace WebService.Interface
{
    public interface IPhieuMuonService : IService<PhieuMuonvm, PhieuMuon>
    {
        Task<Resultreturn<PhieuMuonvm>> GetAllPhieuMuon(SearchParameters searchParameters);
        Task<IList<PhieuMuonvm>> GetAllSearch(string name);
        Task<bool> AddPhieuMuon(PhieuMuonvm model);
        Task<bool> UpdatePhieuMuon(PhieuMuonvm model);
        Task<bool> DeletePhieuMuon(Guid id);
        Task<PhieuMuonvm> GetPhieuMuon(Guid id);
    }
}