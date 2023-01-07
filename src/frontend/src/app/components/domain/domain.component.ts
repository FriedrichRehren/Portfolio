import { Component, OnInit, Input, Inject, LOCALE_ID } from '@angular/core';

@Component({
  selector: 'app-domain',
  templateUrl: './domain.component.html',
  styleUrls: []
})
export class DomainComponent implements OnInit  {

  @Input() name: string = '';
  @Input() description: { [key: string]: string } = {'': ''};

  localeDescription: string = '';

  
  constructor(@Inject(LOCALE_ID) public locale: string) { }

  ngOnInit(): void {
    this.localeDescription = this.description[this.locale]
  }
}
