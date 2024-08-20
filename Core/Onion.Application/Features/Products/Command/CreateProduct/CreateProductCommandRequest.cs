using MediatR;

namespace Onion.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandRequest:IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        //Relations
        public Guid BrandId { get; set; }

        public IList<Guid> CategoryIds { get; set; }
    }
}
