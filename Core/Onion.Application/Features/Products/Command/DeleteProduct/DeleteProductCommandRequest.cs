using MediatR;

namespace Onion.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest
    {
        public Guid Id { get; set; }
    }
}
