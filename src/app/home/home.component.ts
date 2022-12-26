import { Component, Inject, LOCALE_ID } from '@angular/core';
import { Domain } from '../models/domain';
import { Project } from '../models/project';
import { ProjectState } from '../models/project-state';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {

  aboutParagraph1 = $localize`:@@about-paragraph1:I am a developer and enthusiast with more than eight years of experience in developing custom software solutions.`;
  aboutParagraph2 = $localize`:@@about-paragraph2:Creating solutions to benefit everyday tasks and ease workflows has always been my strive.`;
  aboutParagraph3 = $localize`:@@about-paragraph3:I created small CLI-based programs to automate different tasks. Most of which can be found on my <a href=\"https://github.com/FriedrichRehren\" target=\"_blank\" class=\"text-reset\">GitHub</a>.`;
  aboutParagraph4 = $localize`:@@about-paragraph4:I am employed as a freelancer at the <a href=\"https://deutausges.de/\" target=\"_blank\" class=\"text-reset\">Deutsche&nbsp;Auslandsgesellschaft</a>, where I developed multiple internal solutions and built out the networking and server infrastructure. These days I lead the technical preparations for the <a href=\"https://idt-2025.de/\" target=\"_blank\" class=\"text-reset\">IDT&nbsp;2025</a>&nbsp;&ndash;&nbsp;a one&#8209;week&#8209;long conference of german teachers from around the world.`;

  projects: Project[] = [
    new Project(1, {"en": "This Website", "de": "Diese Website"}, {"en": "", "de": ""}, "https://picsum.photos/350/250", ProjectState.inProgress),
    new Project(2, {"en": "Project title", "de": "Projekttitel"}, {"en": "Paragraph of text beneath the heading to explain the heading. We'll add onto it with another sentence and probably just keep going until we run out of words.", "de": "Textabschnitt unter der Überschrift zur Erläuterung der Überschrift. Wir fügen noch einen weiteren Satz hinzu und machen wahrscheinlich so lange weiter, bis uns die Worte ausgehen."}, "https://picsum.photos/700/500", ProjectState.draft)
  ]

  domains: Domain[] = [
    new Domain(1, "friedrichrehren.de", {"en": "Hosting of this page as well as my email service", "de": "Hosting dieser Seite sowie meines E-Mail-Dienstes"}),
    new Domain(2, "rehren.dev", {"en": "Hosting of my PLESK server", "de": "Hosting meines PLESK Servers"}),
    new Domain(3, "rehren.network", {"en": "Hosting of my internal systems", "de": "Hosting meiner internen Systeme"}),
    new Domain(4, "rehren.app", {"en": "Nothing yet", "de": "Noch nichts"}),
    new Domain(5, "rehren.group", {"en": "Nothing yet", "de": "Noch nichts"}),
    new Domain(6, "tanzen-sh.de", {"en": "Currently redirecting to the homepage of TSC Titanium", "de": "Zur Zeit wird auf die Homepage des TSC Titanium weitergeleitet"}),
    new Domain(7, "tanzen.sh", {"en": "Currently redirecting to the homepage of TSC Titanium", "de": "Zur Zeit wird auf die Homepage des TSC Titanium weitergeleitet"})
  ]

  constructor(@Inject(LOCALE_ID) public locale: string) {}

}