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
    public class NalazService : BaseService<Nalaz, NalazVM>
    {
        HttpContextAccessor _context = new HttpContextAccessor();
        QueryString _parametri;

        public NalazService(DBContext db, IMapper mapper, UserManager<User> UsrManger) : base(db, mapper, UsrManger)
        {
            _parametri = _context.HttpContext.Request.QueryString;
        }

        public override List<NalazVM> GetAll()
        {
            var nalazLista = _db.Nalaz.Include(x => x.Pregled).ToList();

            if (_context.HttpContext.Request.QueryString.HasValue)
            {
                var DoktorID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("DoktorID");

                nalazLista = nalazLista.Where(x => x.Pregled.DoktorID == int.Parse(DoktorID)).ToList();
            }

            return _mapper.Map<List<NalazVM>>(nalazLista);
        }
    }
}
