using AutoMapper;
using System.Linq.Expressions;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Interface;
using WebService.Interface;

namespace WebService.Implement
{
    public class LoaiSachService : Service<LoaiSachvm, LoaiSach>, ILoaiSachService
    {
        public LoaiSachService(ILoaiSachRepository loaiSachRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        : base(loaiSachRepository, unitOfWork, mapper)
        {
        }
        public async Task<bool> AddLoaiSach(LoaiSachvm model)
        {
            return await Add(model);
        }
        public async Task<bool> DeleteLoaiSach(int id)
        {
            return await Delete(x=>x.Id ==id);
        }
        public async Task<Resultreturn<LoaiSachvm>> GetAllLoaiSach(SearchParameters searchParameters)
        {
            try
            {
                Paginationpage<LoaiSach> _paginationpage = new Paginationpage<LoaiSach>();
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

        public async Task<LoaiSachvm> GetLoaiSach(int id)
        {
            return await Get(x=>x.Id ==id);
        }
        public async Task<bool> UpdateLoaiSach(LoaiSachvm model)
        {
            return await Update(model);
        }
    }
}