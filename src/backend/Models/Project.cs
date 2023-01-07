namespace Portfolio.Backend.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Linq;

public class Project : BaseModel
{
    [NotMapped]
    public Dictionary<string, string> Name
    {
        get
        {
            XElement nameElement = XElement.Parse(NameXml);
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var el in nameElement.Elements())
                dict.Add(el.Name.LocalName, el.Value);

            return dict;
        }
        set
        {
            XElement el = new XElement("name", value.Select(kv => new XElement(kv.Key, kv.Value)));
            NameXml = el.ToString();
        }
    }

    public string NameXml { get; set; }

    [NotMapped]
    public Dictionary<string, string> Description
    {
        get
        {
            XElement descriptionElement = XElement.Parse(DescriptionXml);
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var el in descriptionElement.Elements())
                dict.Add(el.Name.LocalName, el.Value);

            return dict;
        }
        set
        {
            XElement el = new XElement("description", value.Select(kv => new XElement(kv.Key, kv.Value)));
            DescriptionXml = el.ToString();
        }
    }

    public string DescriptionXml { get; set; }

    public string? ImageUrl { get; set; }
    public string? ProjectUrl { get; set; }
    public ProjectState State { get; set; }

    /// <summary>
    /// Project initialization
    /// </summary>
    public Project()
    {
    }

    /// <summary>
    /// Project initialization from DTO
    /// </summary>
    /// <param name="dto">The ProjectCreateDto</param>
    public Project(ProjectCreateDto dto)
    {
        // Add english name
        SetName(new CultureInfo("en"), dto.EnglishName);

        // Set state to draft
        State = ProjectState.draft;
    }

    public Project(Dictionary<string, string> name, Dictionary<string, string> description)
    {
        Name = name;
        Description = description;

        // Set State to draft
        State = ProjectState.draft;
    }

    public void UpdateWithDto(ProjectUpdateDto dto)
    {
        if (dto.ImageUrl != null && dto.ImageUrl != ImageUrl)
            ImageUrl = dto.ImageUrl;

        if (dto.State != null && dto.State != State)
            State = dto.State.Value;
    }

    public void SetName(CultureInfo culture, string name)
    {
        if (!Name.ContainsKey(culture.TwoLetterISOLanguageName))
            Name[culture.TwoLetterISOLanguageName] = name;
        else
            Name.Add(culture.TwoLetterISOLanguageName, name);
    }

    public void SetDescription(CultureInfo culture, string description)
    {
        if (!Description.ContainsKey(culture.TwoLetterISOLanguageName))
            Description[culture.TwoLetterISOLanguageName] = description;
        else
            Description.Add(culture.TwoLetterISOLanguageName, description);
    }

    public string GetName(CultureInfo culture) =>
        Name.GetValueOrDefault(culture.TwoLetterISOLanguageName, "");

    public string GetDescription(CultureInfo culture) =>
        Description.GetValueOrDefault(culture.TwoLetterISOLanguageName, "");

    public void RemoveName(CultureInfo culture) =>
        Name.Remove(culture.TwoLetterISOLanguageName);

    public void RemoveDescription(CultureInfo culture) =>
        Description.Remove(culture.TwoLetterISOLanguageName);
}