using System.Collections.Generic;
using System.Threading.Tasks;
using TripPlanner.API.Models;

namespace TripPlanner.API.Repository
{
    public interface IRepository<T> where T: class, IEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}