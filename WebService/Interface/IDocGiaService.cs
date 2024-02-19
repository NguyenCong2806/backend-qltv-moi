using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;

namespace WebService.Interface
{
    public interface IDocGiaService: IService<DocGiavm, DocGia>
    {
        Task<Resultreturn<DocGiavm>> GetAllDocGia(SearchParameters searchParameters);
        Task<bool> AddDocGia(DocGiavm model);
        Task<bool> UpdateDocGia(DocGiavm model);
        Task<bool> DeleteDocGia(Guid id);
        Task<DocGiavm> GetDocGia(Guid id);
    }
}