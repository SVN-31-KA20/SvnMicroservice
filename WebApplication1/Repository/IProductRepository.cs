using WebApplication1.Models;

namespace WebApplication1.Repository
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        void Insertproduct(Product product);

        void UpdateProduct(Product product);

        void Deleteproduct(int id);

        void Save();
    }
}
