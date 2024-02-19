using AutoMapper;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Interface;
using WebService.Interface;

namespace WebService.Implement
{
    public class NhaXuatBanService : Service<NhaXuatBanvm, NhaXuatBan>, INhaXuatBanService
    {
        public NhaXuatBanService(INhaXuatBanRepository nhaXuatBanRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        : base(nhaXuatBanRepository, unitOfWork, mapper)
        {
        }
        public async Task<bool> AddNhaXuatBan(NhaXuatBanvm model)
        {
            return await Add(model);
        }
        public async Task<bool> DeleteNhaXuatBan(int id)
        {
            return await Delete(x => x.Id == id);
        }
        public async Task<Resultreturn<NhaXuatBanvm>> GetAllNhaXuatBan(SearchParameters searchParameters)
        {
            try
            {
                Paginationpage<NhaXuatBan> _paginationpage = new Paginationpage<NhaXuatBan>();
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

        public async Task<NhaXuatBanvm> GetNhaXuatBan(int id)
        {
            return await Get(x => x.Id == id);
        }
        public async Task<bool> UpdateNhaXuatBan(NhaXuatBanvm model)
        {
            return await Update(model);
        }
    }
}