using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.Brands.Commands.CreateBrand;
using Onion.Application.Features.Brands.Queries.GetAllBrands;
using Onion.Application.Features.Products.Command.CreateProduct;
using Onion.Application.Features.Products.Command.DeleteProduct;
using Onion.Application.Features.Products.Command.UpdateProduct;
using Onion.Application.Features.Products.Queries.GetAllProducts;

namespace Onion.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await mediator.Send(new GetAllBrandsQueryRequest());
            return Ok(response);
        }
    }
}
