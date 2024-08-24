using Onion.Application.Bases;

namespace Onion.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException :BaseException
    {
        public RefreshTokenShouldNotBeExpiredException():base("Oturum açma süresi dolmuştur,Lütfen tekrar giriş yapınız") { }  
       
    }
}