using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;

namespace WebService.Interface
{
    public interface IChiTietPhieumuonService : IService<ChiTietPhieuMuonvm, ChiTietPhieuMuon>
    {
        Task<Resultreturn<ChiTietPhieuMuonvm>> GetAllChiTietPhieuMuon(SearchParameters searchParameters);
        Task<IList<ChiTietPhieuMuonvm>> GetAllSearch(string name);
        Task<bool> AddChiTietPhieuMuon(ChiTietPhieuMuonvm model);
        Task<bool> AddChiTietPhieuMuon(IList<ChiTietPhieuMuonvm> models);
        Task<bool> UpdateChiTietPhieuMuon(ChiTietPhieuMuonvm model);
        Task<bool> UpdateChiTietPhieuMuon(IList<ChiTietPhieuMuonvm> models);
        Task<bool> DeleteChiTietPhieuMuon(Guid id);
        Task<ChiTietPhieuMuonvm> GetChiTietPhieuMuon(Guid id);
    }
}