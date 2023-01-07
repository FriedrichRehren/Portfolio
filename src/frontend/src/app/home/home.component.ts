import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Domain } from '../_models/domain';
import { Project } from '../_models/project';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: []
})
export class HomeComponent {

  aboutParagraph1 = $localize`:@@about-paragraph1:I am a developer and enthusiast with more than eight years of experience in developing custom software solutions.`;
  aboutParagraph2 = $localize`:@@about-paragraph2:Creating solutions to benefit everyday tasks and ease workflows has always been my strive.`;
  aboutParagraph3 = $localize`:@@about-paragraph3:I created small CLI-based programs to automate different tasks. Most of which can be found on my <a href=\"https://github.com/FriedrichRehren\" target=\"_blank\" class=\"text-reset\">GitHub</a>.`;
  aboutParagraph4 = $localize`:@@about-paragraph4:I am employed as a freelancer at the <a href=\"https://deutausges.de/\" target=\"_blank\" class=\"text-reset\">Deutsche&nbsp;Auslandsgesellschaft</a>, where I developed multiple internal solutions and built out the networking and server infrastructure. These days I lead the technical preparations for the <a href=\"https://idt-2025.de/\" target=\"_blank\" class=\"text-reset\">IDT&nbsp;2025</a>&nbsp;&ndash;&nbsp;a one&#8209;week&#8209;long conference of german teachers from around the world.`;
  
  projects$: Observable<Project[]>;
  domains$: Observable<Domain[]>;

  constructor(private apiService: ApiService) { 
    this.projects$ = this.apiService.getProjects();
    this.domains$ = this.apiService.getDomains();
  }
}
