using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ReportObject>>> GetReport(ReportParameters reportParameters)
        {
            List<int> idsByParameters = new List<int>();
            if(reportParameters.ResponsiblePerson != null)
            {
                string[] names = reportParameters.ResponsiblePerson.Split(" ");
                Employee? employee = context.Employees.FirstOrDefault(e=>e.FirstName == names[0] && e.LastName == names[1]);
                if (employee == null) 
                {
                    return NotFound("Employee does not exist");
                }
                List<int> idsByEmployee = await context.ResponsiblePersons
                    .Where(rp => rp.EmployeeId == employee.Id)
                    .Select(e => e.ServiceId)
                    .ToListAsync();

                idsByParameters.AddRange(idsByEmployee);
            }
            if (reportParameters.Blocks!=null &&reportParameters.Blocks.Count>=0)
            {
                List<int> blockIds = await context.Blocks.Where(b=>reportParameters.Blocks.Contains(b.Code)).Select(b=>b.Id).ToListAsync();

                if (blockIds.Count==0)
                {
                    return NotFound("Blocks do not exist");
                }

                List<int> idsByBlocks = await context.ServiceBlocks.Where(sb => blockIds.Contains(sb.BlockId)).Select(sb => sb.ServiceId).ToListAsync();

                idsByParameters.AddRange(idsByBlocks);
            }

            List<int> idsFromSystems =await IdsFromSystems(reportParameters.Systems);
            if (reportParameters.Systems!=null && reportParameters.Systems.Count >= 0 && idsFromSystems.Count == 0)
            {
                return NotFound("No valid systems were found");
            }
            idsByParameters.AddRange(idsFromSystems);

            List<TechnicalService> services = await context.TechnicalServices.Where(s =>
                (reportParameters.TimeOfCreation == null || s.TimeOfCreation.Date == reportParameters.TimeOfCreation)
                &&(idsByParameters.Count == 0 || idsByParameters.Contains(s.Id)))
                .ToListAsync();
            if (services.Count == 0)
            {
                return NotFound("No services with these parameters exist");
            }

            List<ReportObject> reports = new List<ReportObject>();
            foreach (TechnicalService technicalService in services)
            {
                ReportObject report = new ReportObject();

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
                    .Where(e => e.ServiceId == technicalService.Id)
                    .ToListAsync();
                reports.Add(report);
            }
            return Ok(reports);
        }

        private async Task<List<int>> IdsFromSystems(List<string>? systemCodes)
        {
            List<int> idsFromSystems = new List<int>();
            if (systemCodes!=null && systemCodes.Count>=0)
            {
                List<int> systems = await context.Systems
                    .Where(s => systemCodes.Contains(s.Code)&&s.Parent!=null)
                    .Select(s => (s.Parent != null) ? (int)s.Parent : s.Id)
                    .ToListAsync();
                
                int sIdSizeBefore;
                int sIdSizeAfter = systems.Count;
                do
                {
                    sIdSizeBefore = sIdSizeAfter;

                    List<int> parentSystems = await context.Systems
                        .Where(s =>
                            s.Parent != null &&
                            !systems.Contains((int)s.Parent) &&
                            systems.Contains(s.Id))
                        .Select(s => (s.Parent != null) ? (int)s.Parent : s.Id)
                        .ToListAsync();

                    systems.AddRange(parentSystems);

                    sIdSizeAfter = systems.Count;
                } while (sIdSizeBefore != sIdSizeAfter);

                List<int> children = await context.Systems
                    .Where(s =>
                        !systems.Contains(s.Id)
                        && s.Parent != null
                        && systems.Contains((int)s.Parent))
                    .Select(s => s.Id)
                    .ToListAsync();
                systems.AddRange(children);

                idsFromSystems = await context.ServiceSystems
                    .Where(s => systems
                        .Contains(s.SystemId))
                    .Select(s => s.ServiceId)
                    .ToListAsync();
            }
            await context.SaveChangesAsync();
            return idsFromSystems;
        }
    }
}
