namespace Portfolio.Backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Backend.Data;
using Portfolio.Backend.Models;

[Route("[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger;
    private readonly PortfolioContext _context;

    public ProjectsController(ILogger<ProjectsController> logger, PortfolioContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET: projects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResultDto>>> GetProjects()
    {
        if (_context.Projects == null)
            return NotFound();

        var projects = await GetProjectsFromDb();

        return projects.Select(x => x.ToDto()).ToList();
    }

    // GET: projects/00000000-0000-0000-0000-000000000000
    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectResultDto>> GetProject(Guid id)
    {
        if (_context.Projects == null)
            return NotFound();

        var project = await GetProjectFromDb(id);

        if (project == null)
            return NotFound();

        return project.ToDto();
    }

    // POST: projects
    [HttpPost]
    public async Task<ActionResult<ProjectResultDto>> PostProject(ProjectCreateDto dto)
    {
        if (_context.Projects == null)
            return Problem("Entity set 'PortfolioContext.Projects'  is null.");

        var project = new Project(dto);

        await AddProjectToDb(project);

        return CreatedAtAction("GetProject", new { id = project.Id }, project);
    }

    // PUT: projects/00000000-0000-0000-0000-000000000000
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(Guid id, ProjectUpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var project = await GetProjectFromDb(id);

        project.UpdateWithDto(dto);

        try
        {
            await UpdateProjectFromDb(project);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProjectExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: projects/00000000-0000-0000-0000-000000000000
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        if (_context.Projects == null)
            return NotFound();

        if (ProjectExists(id))
            await DeleteProjectFromDb(id);

        return NoContent();
    }

    private async Task<List<Project>> GetProjectsFromDb()
        => await _context.Projects.ToListAsync();

    private async Task<Project> GetProjectFromDb(Guid id)
        => await _context.Projects.FindAsync(id);

    private async Task AddProjectToDb(Project domain)
    {
        _context.Projects.Add(domain);
        await _context.SaveChangesAsync();
    }

    private async Task UpdateProjectFromDb(Project domain)
    {
        _context.Projects.Update(domain);
        await _context.SaveChangesAsync();
    }

    private async Task DeleteProjectFromDb(Guid id)
    {
        var domain = await GetProjectFromDb(id);
        _context.Projects.Remove(domain);
        await _context.SaveChangesAsync();
    }

    private bool ProjectExists(Guid id)
    {
        return (_context.Projects?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}