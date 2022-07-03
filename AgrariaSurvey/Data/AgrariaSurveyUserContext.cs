using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgrariaSurvey.Data
{
    public class AgrariaSurveyUserContext : IdentityDbContext
    {
        public AgrariaSurveyUserContext(DbContextOptions<AgrariaSurveyUserContext> options)
            : base(options)
        {

        }
    }
}
