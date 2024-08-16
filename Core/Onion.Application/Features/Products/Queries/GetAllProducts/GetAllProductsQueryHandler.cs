using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            List<GetAllProductQueryResponse> response = new();
            foreach (var product in products)
            {
                response.Add(new GetAllProductQueryResponse
                {
                    Name = product.Name,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price= product.Price-(product.Price*product.Discount/100),
                });
            }
            return response;
        }
    }
}
