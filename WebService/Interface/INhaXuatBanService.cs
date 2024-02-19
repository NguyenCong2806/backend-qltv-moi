using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Implement;

namespace WebService.Interface
{
    public interface INhaXuatBanService : IService<NhaXuatBanvm, NhaXuatBan>
    {
        Task<Resultreturn<NhaXuatBanvm>> GetAllNhaXuatBan(SearchParameters searchParameters);
        Task<IList<NhaXuatBanvm>> GetAllNhaXuatBan();
        Task<bool> AddNhaXuatBan(NhaXuatBanvm model);
        Task<bool> UpdateNhaXuatBan(NhaXuatBanvm model);
        Task<bool> DeleteNhaXuatBan(int id);
        Task<NhaXuatBanvm> GetNhaXuatBan(int id);
    }
}