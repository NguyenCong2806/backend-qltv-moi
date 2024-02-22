using AutoMapper;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Interface;
using WebService.Interface;

namespace WebService.Implement
{
    public class PhieuTraService : Service<PhieuTravm, PhieuTra>, IPhieuTraService
    {
        public PhieuTraService(IPhieuTraRepsitory PhieuTraRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        : base(PhieuTraRepository, unitOfWork, mapper)
        {
        }

        public async Task<bool> AddPhieuTra(PhieuTravm model)
        {
            return await Add(model);
        }

        public async Task<bool> DeletePhieuTra(Guid id)
        {
            return await Delete(x => x.Id == id);
        }

        public async Task<Resultreturn<PhieuTravm>> GetAllPhieuTra(SearchParameters searchParameters)
        {
            try
            {
                Paginationpage<PhieuTra> _paginationpage = new Paginationpage<PhieuTra>();
                _paginationpage.PerPage = searchParameters.totalnumber;
                _paginationpage.PageNumber = searchParameters.number;
                if (searchParameters.keywork != null)
                {
                    _paginationpage.Expression.Add(exp => exp.PhieuMuon.DocGia.Name.Contains(searchParameters.keywork));
                }

                return await GetAll(_paginationpage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PhieuTravm> GetPhieuTra(Guid id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<bool> UpdatePhieuTra(PhieuTravm model)
        {
            return await Update(model);
        }
    }
}