using Microsoft.EntityFrameworkCore;

namespace Demo.web.Codes
{
    public class Repository<T> //Common operations for all entities
    {
        public void Add(T product)
        {

        }
        public void Update(T product)
        {

        }
        public void Delete(T product)
        {

        }
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }
    }
    public class ProductRepository : Repository<Product> //Specific Repository (Example: Product)
    {
        //public List<Product> GetBestSellingProducts(int count) //Entity-specific business/query logic
        //{
        //    return _context.Products
        //                   .Where(x => x.Sales > 1000) 
        //                   .Take(count)
        //                   .ToList();
        //}
    }
}
