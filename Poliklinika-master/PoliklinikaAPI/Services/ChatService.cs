using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class ChatService : BaseService<ChatPoruka, ChatPorukaVM>
    {
        HttpContextAccessor _context = new HttpContextAccessor();
        QueryString _parametri;

        public ChatService(DBContext db, IMapper mapper, UserManager<User> UsrManger) : base(db, mapper, UsrManger)
        {
            _parametri = _context.HttpContext.Request.QueryString;
        }

        public override List<ChatPorukaVM> GetAll()
        {
            if (_parametri.HasValue)
            {
                var ChatID = HttpUtility.ParseQueryString(_parametri.ToString()).Get("ID");

                return _mapper.Map<List<ChatPorukaVM>>(_db.ChatPoruka.Where(x => x.ChatObavezaID == int.Parse(ChatID)).ToList());
            }

            return _mapper.Map<List<ChatPorukaVM>>(_db.ChatPoruka.ToList());
        }
    }
}
