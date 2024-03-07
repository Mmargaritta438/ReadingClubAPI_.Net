using Microsoft.AspNetCore.Identity;

namespace BookWebAppAutorization.Data.Indentity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public long AppllicationId { get; set; }
    }
}
