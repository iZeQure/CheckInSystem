using CheckInSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Repository
{
    public interface IRepository<T> : IDisposable where T : BaseEntity
    {
        void Add(T add);
        void Update(T update);
        void Delete(T delete);
        T GetById(string userName);
        List<T> GetAll();
    }
}
