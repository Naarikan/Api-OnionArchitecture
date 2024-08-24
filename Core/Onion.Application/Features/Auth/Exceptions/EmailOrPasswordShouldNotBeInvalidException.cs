using Onion.Application.Bases;

namespace Onion.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Email veya şifre yanlış!") { }
    }
}