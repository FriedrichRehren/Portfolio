namespace Portfolio.Backend.Models;

public static class Extensions
{
    public static ProjectResultDto ToDto(this Project domain) =>
        new ProjectResultDto(domain.Id, domain.Name, domain.Description, domain.ImageUrl, domain.ProjectUrl, domain.State);

    public static DomainResultDto ToDto(this Domain domain) =>
        new DomainResultDto(domain.Id, domain.Name, domain.Description);
}