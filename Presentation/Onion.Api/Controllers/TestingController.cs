using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.Products.Queries.GetAllProducts;

namespace Onion.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
      IMediator mediator;

        public TestingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

     

    }
}
