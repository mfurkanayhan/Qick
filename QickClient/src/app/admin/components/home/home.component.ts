import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FlexiGridModule } from 'flexi-grid'; 
import { QickModel } from '../../models/qick.model';
import { HttpService } from '../../../common/services/http.service';
import { Router, RouterLink } from '@angular/router';
import { FlexiToastService } from 'flexi-toast';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FlexiGridModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export default class HomeComponent {
  qicks = signal<QickModel[]>([]);
  addModel = signal<QickModel>(new QickModel());
  updateModel = signal<QickModel>(new QickModel());

  constructor(
    private http: HttpService,
    private router: Router,
    private toast: FlexiToastService
  ){
    this.getAll();
  }

  gotoRoom(roomNumber: number){
    this.router.navigateByUrl(`/admin/room/${roomNumber}`)
  }

  getAll(){
    this.http.get<QickModel[]>("Qicks/GetAll", (res)=> this.qicks.set(res));
  }

  create(){
    this.http.post<string>("Qicks/Create", this.addModel(), (res)=> {
      this.addModel.set(new QickModel());
      this.getAll();
      this.toast.showToast("Success", "Qick create is successful", "success");
    });
  }
}
