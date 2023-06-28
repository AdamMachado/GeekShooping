using AutoMapper;
using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Model;
using GeekShooping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async  Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Product product = 
                await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            return _mapper.Map<ProductVO>(product);
        }
        public Task<ProductVO> Create(ProductVO vo)
        {
            throw new NotImplementedException();
        }
        public Task<ProductVO> Update(ProductVO vo)
        {
            throw new NotImplementedException();
        }
        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

     
    }
}
