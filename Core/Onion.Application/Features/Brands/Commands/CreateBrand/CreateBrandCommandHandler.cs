using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Onion.Application.Bases;
using Onion.Application.Interfaces.AutoMapper;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : BaseHandler,IRequestHandler<CreateBrandCommandRequest,Unit>
    {
        public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("tr");

            List<Brand> brands = new();

            for (int i = 0; i < 1000000; i++) {

                brands.Add(new(faker.Commerce.Department(1)));
            }

            await _unitOfWork.GetWriteRepository<Brand>().AddRangeASync(brands);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
