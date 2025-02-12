import { Component, OnDestroy, signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SignalrService } from '../../../common/services/signalr.service';

@Component({
  selector: 'app-qick',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './qick.component.html',
  styleUrl: './qick.component.css'
})
export default class QickComponent implements OnDestroy {
  roomNumber = signal<number>(0);
  email = signal<string>("");

  constructor(
    private activated: ActivatedRoute,
    private signalr: SignalrService
  ){
    this.activated.params.subscribe(res => {
      this.roomNumber.set(res["roomNumber"]);
      this.email.set(res["email"]);
      this.signalr.startConnection().then(() => {
        this.signalr.hubConnection!.invoke("JoinQickRoomByParticipant", this.roomNumber().toString(), this.email());
      });
    })
  }

  ngOnDestroy(): void {
    this.signalr.hubConnection!.invoke("LeaveQickRoomByParticipant", this.roomNumber().toString(), this.email());
  }
}
