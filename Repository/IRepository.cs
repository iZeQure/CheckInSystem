using CheckInSystem.Objects;
using System.Collections.Generic;

namespace CheckInSystem.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Add(T add);
        void Update(T update);
        T GetById(string userName);
        List<T> GetAll();
    }
}
