using Onion.Application.Bases;

namespace Onion.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException :BaseException {

        public EmailAddressShouldBeValidException():base("Böyle bir mail adresi bulunmamaktadır."){}
       

    }
}