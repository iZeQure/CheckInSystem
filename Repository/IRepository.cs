using CheckInSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T add);
        void Update(T update);
        void Disable(T disable);
        T GetById(string userName);
        List<T> GetAll();
    }
}
