using MyApp.Models;
using System.Net.Http.Headers;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IProductRepository: IRepository<Products>
    {
        void Update(Products products);
    }
}