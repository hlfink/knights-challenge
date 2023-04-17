import { Injectable } from '@angular/core';
import { knightResponse } from  'src/app/knightResponse';
import { knightRequest } from  'src/app/knightRequest';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class KnightService {

  constructor(private http: HttpClient) { }

  create(entity : knightRequest) :Observable<any>  {
    return this.http.post<any>(Environment.baseApiUrl,entity)
  }

  getAll() : Observable<knightResponse[]> {

    return this.http.get<knightResponse[]>(Environment.baseApiUrl);
  }

  delete(id: string) :Observable<any> {
    return this.http.delete(Environment.baseApiUrl + '/' + id)
  }
}
