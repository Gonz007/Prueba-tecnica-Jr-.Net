import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { enviroment } from 'src/Enviroments/enviroment';
import { Observable } from 'rxjs';
import { Hotel } from '../Interfaces/hotel';

@Injectable({
  providedIn: 'root',
})
export class HotelService {

  private apiUrl: string = `${enviroment.endPoint}api/`;

  constructor(private http: HttpClient) { }

  getList(pageNumber: number, rowsPerPage: number): Observable<Hotel[]> {
    const params = new HttpParams()
      .set('PageNumber', pageNumber.toString())
      .set('RowsPerPage', rowsPerPage.toString());

    return this.http.get<Hotel[]>(`${this.apiUrl}GetInfo`, { params });
  }


  add(hotel: Hotel): Observable<Hotel> {
    return this.http.post<Hotel>(`${this.apiUrl}Createlnfo`, hotel);
  }

  update(id: number, hotel: Hotel): Observable<Hotel> {
    return this.http.put<Hotel>(`${this.apiUrl}Updatelnfo/${id}`, hotel);
  }

  delete(id: number): Observable<Hotel> {
    return this.http.delete<Hotel>(`${this.apiUrl}Deletelnfo/${id}`);
  }
}
