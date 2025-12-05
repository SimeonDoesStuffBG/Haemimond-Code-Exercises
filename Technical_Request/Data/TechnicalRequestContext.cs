using Microsoft.EntityFrameworkCore;

namespace Technical_Request.Data
{
    public class TechnicalRequestContext:DbContext
    {
        public TechnicalRequestContext(DbContextOptions<TechnicalRequestContext> options): base(options) { }
    }
}
