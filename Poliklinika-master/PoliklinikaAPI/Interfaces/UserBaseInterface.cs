using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.Interfaces
{
    public interface UserBaseInterface<T, TVM, TCreateVM>
    {
        public IList<TVM> GetAll();
        public TVM Get(int id);
        public Task<TVM> Insert(TCreateVM user);
        public TVM Update(TVM user);
        public void Delete(int id);
        public void UpdatePassword(UpdatePasswordVM update);
    }
}
