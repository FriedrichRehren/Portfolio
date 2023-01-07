namespace Portfolio.Backend.Models;

using System.Globalization;

#region Domain

public record DomainResultDto(Guid Id, string Name, Dictionary<string, string> Description);
public record DomainCreateDto(string Name);
public record DomainUpdateDto(Guid Id, string? Name);
public record DomainSetDescriptionDto(Guid Id, CultureInfo culture, string Description);
public record DomainDeleteDescriptionDto(Guid Id, CultureInfo culture);

#endregion Domain

#region Project

public record ProjectResultDto(Guid Id, Dictionary<string, string> Name, Dictionary<string, string> Description, string? ImageUrl, string? ProjectUrl, ProjectState State);
public record ProjectCreateDto(string EnglishName);
public record ProjectUpdateDto(Guid Id, string? ImageUrl, string? ProjectUrl, ProjectState? State);
public record ProjectSetNameDto(Guid Id, CultureInfo culture, string Name);
public record ProjectDeleteNameDto(Guid Id, CultureInfo culture);
public record ProjectSetDescriptionDto(Guid Id, CultureInfo culture, string Description);
public record ProjectDeleteDescriptionDto(Guid Id, CultureInfo culture);

#endregion Project