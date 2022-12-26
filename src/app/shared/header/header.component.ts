import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  aboutAnchorLink: string = $localize`:@@about-anchor:about`;
  projectsAnchorLink: string = $localize`:@@projects-anchor:projects`;
  domainsAnchorLink: string = $localize`:@@domains-anchor:domains`;

  constructor() { }

}
