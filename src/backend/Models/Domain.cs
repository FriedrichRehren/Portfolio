namespace Portfolio.Backend.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Linq;

public class Domain : BaseModel
{
    public string Name { get; set; }

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

    /// <summary>
    /// Domain initialization
    /// </summary>
    public Domain()
    {
    }

    /// <summary>
    /// Domain initialization from DTO
    /// </summary>
    /// <param name="dto">The DomainCreateDto</param>
    public Domain(DomainCreateDto dto)
    {
        Name = dto.Name;
    }

    public Domain(string name, Dictionary<string, string> description)
    {
        Name = name;
        Description = description;
    }

    public void UpdateWithDto(DomainUpdateDto dto)
    {
        if (dto.Name != null && dto.Name != Name)
            Name = dto.Name;
    }

    public void SetDescription(CultureInfo culture, string description)
    {
        if (!Description.ContainsKey(culture.TwoLetterISOLanguageName))
            Description[culture.TwoLetterISOLanguageName] = description;
        else
            Description.Add(culture.TwoLetterISOLanguageName, description);
    }

    public string GetDescription(CultureInfo culture) =>
        Description.GetValueOrDefault(culture.TwoLetterISOLanguageName, "");

    public void RemoveDescription(CultureInfo culture) =>
        Description.Remove(culture.TwoLetterISOLanguageName);
}