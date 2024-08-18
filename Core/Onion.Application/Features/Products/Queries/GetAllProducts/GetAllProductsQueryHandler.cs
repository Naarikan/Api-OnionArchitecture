using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Onion.Application.DTOs;
using Onion.Application.Interfaces.AutoMapper;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include:x=>x.Include(b=>b.Brand));

            var brand=mapper.Map<BrandDto,Brand>(new Brand());

            var map = mapper.Map<GetAllProductQueryResponse, Product>(products);

            List<GetAllProductQueryResponse> response = new();
            foreach (var item in map)
                item.Price = item.Price - (item.Price*item.Discount/100);


            return map;
          
        }
    }
}
