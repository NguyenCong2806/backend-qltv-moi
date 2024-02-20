using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEntryModel;
using WebEntryModel.EF;
using WebRepository.Interface;

namespace WebRepository.Implement
{
    public class PhieuMuonRepository : Repository<PhieuMuon>, IPhieuMuonRepository
    {
        public PhieuMuonRepository(AppDatabase appDatabase) : base(appDatabase)
        {
        }
    }
}