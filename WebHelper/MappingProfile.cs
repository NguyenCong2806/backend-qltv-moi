using AutoMapper;
using WebDataModel.ViewModel;
using WebEntryModel.EF;

namespace WebHelper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Uservm, Userview>();
            CreateMap<Userview, Uservm>();

            CreateMap<ChiTietPhieuMuonvm, ChiTietPhieuMuon>();
            CreateMap<ChiTietPhieuMuon, ChiTietPhieuMuonvm>();

            CreateMap<DocGiavm, DocGia>();
            CreateMap<DocGia, DocGiavm>();

            CreateMap<LoaiSachvm, LoaiSach>();
            CreateMap<LoaiSach, LoaiSachvm>();

            CreateMap<NhaXuatBanvm, NhaXuatBan>();
            CreateMap<NhaXuatBan, NhaXuatBanvm>();

            CreateMap<PhieuMuonvm, PhieuMuon>();
            CreateMap<PhieuMuon, PhieuMuonvm>();

            CreateMap<PhieuTravm, PhieuTra>();
            CreateMap<PhieuTra, PhieuTravm>();

            CreateMap<Sachvm, Sach>();
            CreateMap<Sach, Sachvm>();
        }
    }
}