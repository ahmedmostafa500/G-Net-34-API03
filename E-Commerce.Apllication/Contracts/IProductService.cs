using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Apllication.Common;
using E_Commerce.Apllication.DTOS.Products;

namespace E_Commerce.Apllication.Contracts
{
    public interface IProductService
    {
        Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct = default);
        Task<Result<ProductDto>> GetProductAsync(int id, CancellationToken ct=default);

        Task<Result<IReadOnlyList<BrandDto>>>GetAllBrandsAsync(CancellationToken ct=default);

        Task<Result<IReadOnlyList<TypeDto>>>GetAllTypesAsync(CancellationToken ct=default);
    }
}
