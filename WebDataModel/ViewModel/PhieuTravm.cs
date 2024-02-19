namespace WebDataModel.ViewModel
{
    public class PhieuTravm
    {
        public Guid Id { get; set; } = new Guid();

        public Guid PhieuMuonId { get; set; }

        public DateTime? NgayTra { get; set; } = DateTime.Now;
        public PhieuMuonvm? PhieuMuon { get; set; }
    }
}