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
    public class ObavezaServis : BaseService<Obaveza, ObavezaVM>
    {
        HttpContextAccessor _context = new HttpContextAccessor();
        QueryString _parametri;

        public ObavezaServis(DBContext db, IMapper mapper, UserManager<User> UsrManger) : base(db, mapper, UsrManger)
        {
            _parametri = _context.HttpContext.Request.QueryString;
        }

        public override List<ObavezaVM> GetAll()
        {
            List<ObavezaVM> lista = new List<ObavezaVM>();
            if (_parametri.HasValue)
            {
                var OsobljeID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("OsobljeID");

                if (OsobljeID == null || OsobljeID == "" || OsobljeID =="0")
                {
                     lista = _mapper.Map<List<ObavezaVM>>
                        (_db.Obaveza)
                        .ToList();
                }
                else
                {

                    lista = _mapper.Map<List<ObavezaVM>>(_db.Obaveza.Where(x => x.OsobljeID == int.Parse(OsobljeID)).ToList());
                }

                if (HttpUtility.ParseQueryString(_parametri.ToString()).Get("Aktivna") == "True")
                    return _mapper.Map<List<ObavezaVM>>(lista.Where(x => x.Aktivna).ToList());
                else
                    return _mapper.Map<List<ObavezaVM>>(lista.Where(x => !x.Aktivna).ToList());

            }

            return _mapper.Map<List<ObavezaVM>>(_db.Obaveza.ToList());
        }

        public override ObavezaVM GetById(int id)
        {
            var chat = _db.ChatObaveza.FirstOrDefault(x => x.ObavezaID == id);
            var obavezaVM = _mapper.Map<ObavezaVM>(_db.Obaveza.Find(id));

            if (chat != null)
                obavezaVM.ChatID = chat.ID;

            return obavezaVM;
        }
    }
}
