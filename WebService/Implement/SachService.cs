using AutoMapper;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Interface;
using WebService.Interface;

namespace WebService.Implement
{
    public class SachService : Service<Sachvm, Sach>, ISachService
    {
        public SachService(ISachRepository SachRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        : base(SachRepository, unitOfWork, mapper)
        {
        }

        public async Task<bool> AddSach(Sachvm model)
        {
            return await Add(model);
        }

        public async Task<bool> DeleteSach(Guid id)
        {
            return await Delete(x => x.Id == id);
        }

        public async Task<Resultreturn<Sachvm>> GetAllSach(SearchParameters searchParameters)
        {
            try
            {
                Paginationpage<Sach> _paginationpage = new Paginationpage<Sach>();
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

        public async Task<Sachvm> GetSach(Guid id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<bool> UpdateSach(Sachvm model)
        {
            return await Update(model);
        }
    }
}