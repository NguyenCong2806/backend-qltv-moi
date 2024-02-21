using AutoMapper;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Interface;
using WebService.Interface;

namespace WebService.Implement
{
    public class ChiTietPhieumuonService : Service<ChiTietPhieuMuonvm, ChiTietPhieuMuon>, 
        IChiTietPhieumuonService
    {
        public ChiTietPhieumuonService(IChiTietPhieuMuonRepository ChiTietPhieuMuonRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        : base(ChiTietPhieuMuonRepository, unitOfWork, mapper)
        {
        }

        public async Task<bool> AddChiTietPhieuMuon(ChiTietPhieuMuonvm model)
        {
            return await Add(model);
        }

        public async Task<bool> AddChiTietPhieuMuon(IList<ChiTietPhieuMuonvm> models)
        {
            return await Add(models);
        }

        public async Task<bool> DeleteAllChiTietPhieuMuon(Guid id)
        {
            return await DeleteAll(x => x.PhieuMuonId == id);
        }

        public async Task<bool> DeleteChiTietPhieuMuon(Guid id)
        {
            return await Delete(x => x.Id == id);
        }

        public async Task<Resultreturn<ChiTietPhieuMuonvm>> GetAllChiTietPhieuMuon(SearchParameters searchParameters)
        {
            try
            {
                Paginationpage<ChiTietPhieuMuon> _paginationpage = new Paginationpage<ChiTietPhieuMuon>();
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

        public async Task<IList<ChiTietPhieuMuonvm>> GetAllSearch(Guid Id)
        {
            return await GetAll(x => x.PhieuMuon.Id ==Id);
        }

        public async Task<ChiTietPhieuMuonvm> GetChiTietPhieuMuon(Guid id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<bool> UpdateChiTietPhieuMuon(ChiTietPhieuMuonvm model)
        {
            return await Update(model);
        }

        public async Task<bool> UpdateChiTietPhieuMuon(IList<ChiTietPhieuMuonvm> models)
        {
            return await Update(models);
        }
    }
}