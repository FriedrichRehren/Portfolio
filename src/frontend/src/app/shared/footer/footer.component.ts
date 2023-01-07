import { Component } from '@angular/core';
import { faGithub, IconDefinition } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: []
})
export class FooterComponent {

  currentYear: number = new Date().getFullYear();

  githubIcon: IconDefinition = faGithub;

  constructor() { }

}
