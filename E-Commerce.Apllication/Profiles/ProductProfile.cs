using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Apllication.DTOS.Products;
using E_Commerce.Domain.Entities.Products;

namespace E_Commerce.Apllication.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, p => p.MapFrom(s => s.productBrand.Name))
                .ForMember(d => d.ProductType, p => p.MapFrom(s => s.productType.Name));

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
        }
    }
}
