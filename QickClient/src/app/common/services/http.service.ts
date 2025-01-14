import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { ResultModel } from '../models/result.model';
import { FlexiToastService } from 'flexi-toast';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  mainApi = signal<string>("https://localhost:7276");

  constructor(
    private http: HttpClient,
    private toast: FlexiToastService
  ) {
    this.toast.options.autoClose=true;
   }

  get<T>(endpoint: string, callBack: (res: T)=> void, errorCallBack?: (err: HttpErrorResponse) => void)
  {
    this.http.get<ResultModel<T>>(`${this.mainApi()}/api/${endpoint}`).subscribe({
      next: (res)=> {
        callBack(res.data!);
      },
      error: (err: HttpErrorResponse | any) => {
        if(errorCallBack !== null && errorCallBack !== undefined){
          errorCallBack(err);
        }

        console.log(err);

        if (err.status === 500){
          this.toast.showToast("Error", err.error.errorMessage[0], "error");
        }
      }
    })
  }

  post<T>(endpoint: string, body:any, callBack: (res: T)=> void, errorCallBack?: (err: HttpErrorResponse) => void)
  {
    this.http.post<ResultModel<T>>(`${this.mainApi()}/api/${endpoint}`,body).subscribe({
      next: (res)=> {
        callBack(res.data!);
      },
      error: (err: HttpErrorResponse) => {
        if(errorCallBack !== null && errorCallBack !== undefined){
          errorCallBack(err);
        }
      }
    })
  }
}
