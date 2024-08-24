using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Onion.Application.Bases;
using Onion.Application.Features.Auth.Rules;
using Onion.Application.Interfaces.AutoMapper;
using Onion.Application.Interfaces.Tokens;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler,IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManger;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public LoginCommandHandler(IMapper mapper,IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, AuthRules authRules, UserManager<User> userManger,
            ITokenService tokenService,IConfiguration configuration) :base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManger = userManger;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManger.FindByEmailAsync(request.Email);
            bool checkPassword = await userManger.CheckPasswordAsync(user, request.Password);
            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> roles = await userManger.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();

          

            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTiem = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManger.UpdateAsync(user);
            await userManger.UpdateSecurityStampAsync(user);

            string _token=new JwtSecurityTokenHandler().WriteToken(token);

            await userManger.SetAuthenticationTokenAsync(user , "Default", "AccessToken",_token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };


        }
    }
}
