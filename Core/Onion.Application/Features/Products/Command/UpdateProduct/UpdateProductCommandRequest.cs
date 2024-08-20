using MediatR;

namespace Onion.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandRequest:IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        //Relations
        public Guid BrandId { get; set; }

        public IList<Guid> CategoryIds { get; set; }
    }
}
