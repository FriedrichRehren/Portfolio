namespace Portfolio.Backend.Data;

using Portfolio.Backend.Models;

public static class DbInitializer
{
    public static void Initialize(PortfolioContext context)
    {
        context.Database.EnsureCreated();

        //if (context.Projects.Any())
        //{
        //    return;
        //}

        var projects = new Project[]
        {
            new()
            {
                Name = new() {
                    { "en", "This Website" },
                    { "de", "Diese Website" }
                },
                Description = new()
                {
                    { "en", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!" },
                    { "de", "Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia, molestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum numquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium optio, eaque rerum!" }
                },
                ImageUrl = "https://picsum.photos/350/250",
                ProjectUrl = "https://github.com/FriedrichRehren/Portfolio",
                State = ProjectState.inProgress
            },
            new()
            {
                Name = new() {
                    { "en", "Project title" },
                    { "de", "Projekttitel" }
                },
                Description = new() {
                    { "en", "Paragraph of text beneath the heading to explain the heading. We'll add onto it with another sentence and probably just keep going until we run out of words." },
                    { "de", "Textabschnitt unter der Überschrift zur Erläuterung der Überschrift. Wir fügen noch einen weiteren Satz hinzu und machen wahrscheinlich so lange weiter, bis uns die Worte ausgehen." }
                },
                ImageUrl = "https://picsum.photos/350/250",
                State = ProjectState.draft
            }
        };

        context.Projects.AddRange(projects);

        var domains = new Domain[]
        {
            new()
            {
                Name = "friedrichrehren.de",
                Description = new() {
                    { "en", "Hosting of this page as well as my email service" },
                    { "de", "Hosting dieser Seite sowie meines E-Mail-Dienstes" }
                }
            },
            new()
            {
                Name = "rehren.dev",
                Description = new() {
                    { "en", "Hosting of my PLESK server" },
                    { "de", "Hosting meines PLESK Servers" }
                }
            },
            new()
            {
                Name = "rehren.network",
                Description = new() {
                    { "en", "Hosting of my internal systems" },
                    { "de", "Hosting meiner internen Systeme" }
                }
            },
            new()
            {
                Name = "rehren.app",
                Description = new() {
                    { "en", "Nothing yet" },
                    { "de", "Noch nichts" }
                }
            },
            new()
            {
                Name = "rehren.group",
                Description = new() {
                    { "en", "Nothing yet" },
                    { "de", "Noch nichts" }
                }
            },
            new()
            {
                Name = "tanzen-sh.de",
                Description = new() {
                    { "en", "Currently redirecting to the homepage of TSC Titanium" },
                    { "de", "Zur Zeit wird auf die Homepage des TSC Titanium weitergeleitet" }
                }
            },
            new()
            {
                Name = "tanzen.sh",
                Description = new() {
                    { "en", "Currently redirecting to the homepage of TSC Titanium" },
                    { "de", "Zur Zeit wird auf die Homepage des TSC Titanium weitergeleitet" }
                }
            },
        };

        context.Domains.AddRange(domains);

        context.SaveChanges();
    }
}