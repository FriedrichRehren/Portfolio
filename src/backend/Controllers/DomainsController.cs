namespace Portfolio.Backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Backend.Data;
using Portfolio.Backend.Models;

[Route("[controller]")]
[ApiController]
public class DomainsController : ControllerBase
{
    private readonly ILogger<DomainsController> _logger;
    private readonly PortfolioContext _context;

    public DomainsController(ILogger<DomainsController> logger, PortfolioContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET: domains
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DomainResultDto>>> GetDomains()
    {
        if (_context.Domains == null)
            return NotFound();

        var domains = await GetDomainsFromDb();

        return domains.Select(x => x.ToDto()).ToList();
    }

    // GET: domains/00000000-0000-0000-0000-000000000000
    [HttpGet("{id}")]
    public async Task<ActionResult<DomainResultDto>> GetDomain(Guid id)
    {
        if (_context.Domains == null)
            return NotFound();

        var domain = await GetDomainFromDb(id);

        if (domain == null)
            return NotFound();

        return domain.ToDto();
    }

    // POST: domains
    [HttpPost]
    public async Task<ActionResult<DomainResultDto>> PostDomain(DomainCreateDto dto)
    {
        if (_context.Domains == null)
            return Problem("Entity set 'PortfolioContext.Domains'  is null.");

        var domain = new Domain(dto);

        await AddDomainToDb(domain);

        return CreatedAtAction("GetDomain", new { id = domain.Id }, domain);
    }

    // PUT: domains/00000000-0000-0000-0000-000000000000
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDomain(Guid id, DomainUpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var domain = await GetDomainFromDb(id);

        domain.UpdateWithDto(dto);

        try
        {
            await UpdateDomainFromDb(domain);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DomainExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: domains/00000000-0000-0000-0000-000000000000
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDomain(Guid id)
    {
        if (_context.Domains == null)
            return NotFound();

        if (DomainExists(id))
            await DeleteDomainFromDb(id);

        return NoContent();
    }

    private async Task<List<Domain>> GetDomainsFromDb()
        => await _context.Domains.ToListAsync();

    private async Task<Domain> GetDomainFromDb(Guid id)
        => await _context.Domains.FindAsync(id);

    private async Task AddDomainToDb(Domain domain)
    {
        _context.Domains.Add(domain);
        await _context.SaveChangesAsync();
    }

    private async Task UpdateDomainFromDb(Domain domain)
    {
        _context.Domains.Update(domain);
        await _context.SaveChangesAsync();
    }

    private async Task DeleteDomainFromDb(Guid id)
    {
        var domain = await GetDomainFromDb(id);
        _context.Domains.Remove(domain);
        await _context.SaveChangesAsync();
    }

    private bool DomainExists(Guid id)
    {
        return (_context.Domains?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}