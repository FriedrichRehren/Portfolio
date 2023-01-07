import { Component, OnInit, Input, Inject, LOCALE_ID } from '@angular/core';
import { faUpRightFromSquare } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: []
})
export class ProjectComponent implements OnInit {

  @Input() name: { [key: string]: string } = {'': ''};
  @Input() description: { [key: string]: string } = {'': ''};
  @Input() imageUrl: string = '';
  @Input() projectUrl: string = '';

  localeName: string = '';
  localeDescription: string = '';

  externalLinkIcon = faUpRightFromSquare;
  
  constructor(@Inject(LOCALE_ID) public locale: string) { }

  ngOnInit(): void {
    this.localeName = this.name[this.locale]
    this.localeDescription = this.description[this.locale]
  }
}
