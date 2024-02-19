using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;

namespace WebService.Interface
{
    public interface ILoaiSachService: IService<LoaiSachvm, LoaiSach>
    {
        Task<Resultreturn<LoaiSachvm>> GetAllLoaiSach(SearchParameters searchParameters);
        Task<IList<LoaiSachvm>> GetAllLoaiSach();
        Task<bool> AddLoaiSach(LoaiSachvm model);
        Task<bool> UpdateLoaiSach(LoaiSachvm model);
        Task<bool> DeleteLoaiSach(int id);
        Task<LoaiSachvm> GetLoaiSach(int id);
    }
}