using AutoMapper;
using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoliklinikaAPI.ViewModels;

namespace PoliklinikaAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, SignupAdminVM>().ReverseMap();

            CreateMap<Korisnik, KorisnikVM>().ReverseMap();
            CreateMap<Korisnik, SignUpKorisnikVM>().ReverseMap();
            CreateMap<KorisnikVM, SignUpKorisnikVM>().ReverseMap();

            CreateMap<Doktor, DoktorVM>().ReverseMap();
            CreateMap<Doktor, CreateDoktorVM>().ReverseMap();
            CreateMap<DoktorVM, CreateDoktorVM>().ReverseMap();

            CreateMap<Tehnicar, TehnicarVM>().ReverseMap();
            CreateMap<Tehnicar, CreateTehnicarVM>().ReverseMap();
            CreateMap<TehnicarVM, CreateTehnicarVM>().ReverseMap();

            CreateMap<Osoblje, OsobljeVM>().ReverseMap();
            CreateMap<Pregled, PregledVM>().ReverseMap();
            CreateMap<Uplata, UplataVM>().ReverseMap();
            CreateMap<Odjel, OdjelVM>().ReverseMap();
            CreateMap<Nalaz, NalazVM>().ReverseMap();
            CreateMap<Obaveza, ObavezaVM>().ReverseMap();
            CreateMap<Izvjestaj, IzvjestajVM>().ReverseMap();
            CreateMap<ChatObaveza, ChatObavezaVM>().ReverseMap();
            CreateMap<ChatPoruka, ChatPorukaVM>().ReverseMap();
            CreateMap<Raspored, RasporedVM>().ReverseMap();
            CreateMap<Konsultacije, KonsultacijeVM>().ReverseMap();
            CreateMap<KonsultacijePoruka, KonsultacijePorukaVM>().ReverseMap();
        }
    }
}
