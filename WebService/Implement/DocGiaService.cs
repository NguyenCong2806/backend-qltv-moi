using AutoMapper;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Interface;
using WebService.Interface;

namespace WebService.Implement
{
    public class DocGiaService : Service<DocGiavm, DocGia>, IDocGiaService
    {
        public DocGiaService(IDocGiaRepository DocGiaRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        : base(DocGiaRepository, unitOfWork, mapper)
        {
        }

        public async Task<bool> AddDocGia(DocGiavm model)
        {
            return await Add(model);
        }

        public async Task<bool> DeleteDocGia(Guid id)
        {
            return await Delete(x => x.Id == id);
        }

        public async Task<Resultreturn<DocGiavm>> GetAllDocGia(SearchParameters searchParameters)
        {
            try
            {
                Paginationpage<DocGia> _paginationpage = new Paginationpage<DocGia>();
                _paginationpage.PerPage = searchParameters.totalnumber;
                _paginationpage.PageNumber = searchParameters.number;
                if (searchParameters.keywork != null)
                {
                    _paginationpage.Expression.Add(exp => exp.Name.Contains(searchParameters.keywork));
                }

                return await GetAll(_paginationpage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DocGiavm> GetDocGia(Guid id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<bool> UpdateDocGia(DocGiavm model)
        {
            return await Update(model);
        }
    }
}