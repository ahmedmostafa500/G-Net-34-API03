using E_Commerce.Apllication.Common;
using E_Commerce.Apllication.Contracts;
using E_Commerce.Apllication.DTOS.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{

    public class ProductController(IProductService productservice) : APIBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProducts(CancellationToken ct)
        {
            var products = await productservice.GetAllProductsAsync(ct);
            return ToActionResult(products);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductDto>> GetProduct(int id, CancellationToken ct)
        {
            var product= await productservice.GetProductAsync(id,ct);
            return ToActionResult(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetAllBrands(CancellationToken ct)
        => ToActionResult(await productservice.GetAllBrandsAsync(ct));

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDto>>> GetAllTypes(CancellationToken ct)
            =>ToActionResult(await productservice.GetAllTypesAsync(ct));

        
        
    }
}
    
        
        
    

