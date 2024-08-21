using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Features.Products.Rules;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules productRules; 

        public CreateProductCommandHandler(IUnitOfWork unitOfWork , ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            this.productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products,request.Name);

            Product product = new(request.Name,request.Description,request.Price,request.Discount,request.BrandId);

            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var item in request.CategoryIds)

                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {

                        ProductId = product.Id,
                        CategoryId = item


                    });
                await _unitOfWork.SaveAsync();
            }
            return Unit.Value;
        }
    }
}
