using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical_Request.Data;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly TechnicalRequestContext context;
        public ReportController(TechnicalRequestContext _context)
        {
            context = _context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportObject>> GetReport(int id)
        {
            ReportObject report = new ReportObject();
            TechnicalService? technicalService = context.TechnicalServices.Find(id);
            if (technicalService == null)
            {
                return NotFound();
            }
            report.Name = technicalService.Name;
            report.Description = technicalService.Description;
            report.TimeOfCreation = technicalService.TimeOfCreation;
            report.Blocks = await context.Blocks
                .FromSql($@"GetBlocks @ServiceId = {technicalService.Id}")
                .ToListAsync();
            report.Systems = await context.Systems
                .FromSql($@"GetSystems @ServiceId = {technicalService.Id}")
                .ToListAsync();
            report.ResponsiblePersons = await context.ResponsiblePersonActivities
                .Where(e=>e.ServiceId == technicalService.Id)
                .ToListAsync();
            return Ok(report);
        }
    }
}
