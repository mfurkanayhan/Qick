import { Component, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-qick',
  standalone: true,
  imports: [],
  templateUrl: './qick.component.html',
  styleUrl: './qick.component.css'
})
export default class QickComponent {
  roomNumber = signal<number>(0);

  constructor(
    private activated: ActivatedRoute
  ){
    this.activated.params.subscribe(res => {
      this.roomNumber.set(res["roomNumber"]);
    })
  }
}
