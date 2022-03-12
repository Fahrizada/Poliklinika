using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Model;
using PoliklinikaAPI.Data;
using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PoliklinikaAPI.Services
{
    public class IzvjestajService : BaseService<Izvjestaj, IzvjestajVM>
    {
        HttpContextAccessor _context = new HttpContextAccessor();
        QueryString _parametri;

        public IzvjestajService(DBContext db, IMapper mapper, UserManager<User> UsrManger) : base(db, mapper, UsrManger)
        {
            _parametri = _context.HttpContext.Request.QueryString;
        }

        public override List<IzvjestajVM> GetAll()
        {
            var query = _db.Set<Izvjestaj>().Include(x => x.Pregled.Doktor).OrderBy(x => x.Pregled.Doktor.Prezime).AsQueryable();

            if (_parametri.HasValue)
            {
                var OdjelID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("OdjelID");
                var DoktorID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("DoktorID");

                if(OdjelID != null && OdjelID != "" && OdjelID != "0")
                    query = query.Where(x => x.Pregled.Doktor.OdjelID == int.Parse(OdjelID));
                if(DoktorID != null && DoktorID != "" && DoktorID != "0")
                    query = query.Where(x => x.Pregled.DoktorID == int.Parse(DoktorID));
            }
            
            return _mapper.Map<List<IzvjestajVM>>(query.ToList());
        }

    }
}
