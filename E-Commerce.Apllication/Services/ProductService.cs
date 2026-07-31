using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Apllication.Common;
using E_Commerce.Apllication.Contracts;
using E_Commerce.Apllication.DTOS.Products;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;

namespace E_Commerce.Apllication.Services
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct = default)
        {
            var Repo = _unitOfWork.GetRepository<Product,int>();
            var Products= await Repo.GetAllAsync(ct);
            var Data=_mapper.Map<IReadOnlyList<ProductDto>>(Products);
            return Result<IReadOnlyList<ProductDto>> .Ok(Data);
        }

        public async Task<Result<ProductDto>> GetProductAsync(int id, CancellationToken ct = default)
        {
           var Product= await _unitOfWork.GetRepository<Product,int>().GetByIdAsync(id,ct);
            if (Product is null)
            {
                return Result<ProductDto>.Fail(Error.NotFound("Product.NotFound", $"Product With Id:{id} Was Not Found"));
            }
            return _mapper.Map<ProductDto>(Product);    
        }

        public async Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default)
        {
          var Types= await _unitOfWork.GetRepository<ProductType , int>().GetAllAsync(ct);
            return Result<IReadOnlyList<TypeDto>>.Ok(_mapper.Map<IReadOnlyList<TypeDto>>(Types));
        }

        public async Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct = default)
        {
            var Brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync(ct);
            return Result<IReadOnlyList<BrandDto>>.Ok(_mapper.Map<IReadOnlyList<BrandDto>>(Brands));
        }
    }
}
