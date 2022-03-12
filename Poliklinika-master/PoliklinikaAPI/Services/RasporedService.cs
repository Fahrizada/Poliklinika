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
    public class RasporedService : BaseService<Raspored, RasporedVM>
    {
        HttpContextAccessor _context = new HttpContextAccessor();
        QueryString _parametri;

        public RasporedService(DBContext db, IMapper mapper, UserManager<User> UsrManger) : base(db, mapper, UsrManger)
        {
            _parametri = _context.HttpContext.Request.QueryString;
        }

        public override List<RasporedVM> GetAll()
        {
            var rasporedi = _db.Raspored.Include(x => x.Pregled).ToList();
            
            if (!_parametri.HasValue)
                return _mapper.Map<List<RasporedVM>>(rasporedi);

            var DoktorID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("DoktorID");
            var TehnicarID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("TehnicarID");
            var Datum = HttpUtility.ParseQueryString(_parametri.ToString()).Get("Datum");
            var OdjelID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("OdjelID");

            if (DoktorID != "0" && DoktorID != null)
                rasporedi = rasporedi.Where(x => x.DoktorID == int.Parse(DoktorID)).ToList();
            else if (TehnicarID != "0" && TehnicarID != null)
                rasporedi = rasporedi.Where(x => x.TehnicarID == int.Parse(TehnicarID)).ToList();
            else
            {
                var datum = Datum.Split(" ")[0].Replace('-', '.');
                rasporedi = rasporedi.Where(x => x.Datum.Date.ToString("yyyy.MM.dd") == datum &&
                x.Pregled.OdjelID == int.Parse(OdjelID)).ToList();
            }

            return _mapper.Map<List<RasporedVM>>(rasporedi);
        }
    }
}
