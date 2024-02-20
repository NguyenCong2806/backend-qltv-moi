using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebEntryModel.EF;
using WebRepository.Interface;
using WebService.Interface;

namespace WebService.Implement
{
    public class PhieuMuonService : Service<PhieuMuonvm, PhieuMuon>, IPhieuMuonService
    {
        public PhieuMuonService(IPhieuMuonRepository PhieuMuonRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        : base(PhieuMuonRepository, unitOfWork, mapper)
        {
        }

        public async Task<bool> AddPhieuMuon(PhieuMuonvm model)
        {
            return await Add(model);
        }

        public async Task<bool> DeletePhieuMuon(Guid id)
        {
            return await Delete(x => x.Id == id);
        }

        public async Task<Resultreturn<PhieuMuonvm>> GetAllPhieuMuon(SearchParameters searchParameters)
        {
            try
            {
                Paginationpage<PhieuMuon> _paginationpage = new Paginationpage<PhieuMuon>();
                _paginationpage.PerPage = searchParameters.totalnumber;
                _paginationpage.PageNumber = searchParameters.number;
                if (searchParameters.keywork != null)
                {
                    _paginationpage.Expression.Add(exp => exp.DocGia.Name.Contains(searchParameters.keywork));
                }

                return await GetAll(_paginationpage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<PhieuMuonvm>> GetAllSearch(string name)
        {
            return await GetAll(x => x.DocGia.Name.Contains(name));
        }

        public async Task<PhieuMuonvm> GetPhieuMuon(Guid id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<bool> UpdatePhieuMuon(PhieuMuonvm model)
        {
            return await Update(model);
        }
    }
}