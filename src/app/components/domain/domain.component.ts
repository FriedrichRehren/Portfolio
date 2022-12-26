import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-domain',
  templateUrl: './domain.component.html',
  styleUrls: ['./domain.component.scss']
})
export class DomainComponent  {

  @Input() name: string = '';
  @Input() description: string = '';

  constructor() { }

}
