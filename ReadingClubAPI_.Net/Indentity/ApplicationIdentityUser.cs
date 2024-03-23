using Microsoft.AspNetCore.Identity;

namespace ReadingClubSPI_.Net.Indentity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public long AppllicationId { get; set; }
    }
}
