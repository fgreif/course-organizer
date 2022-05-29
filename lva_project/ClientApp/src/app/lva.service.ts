import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';
import { Lva } from './models/lva';

@Injectable({
  providedIn: 'root'
})
export class LvaService {

  constructor(private readonly _configService: ConfigService) { }

  public getLvas(): Observable<Lva[]> {
    return this._configService.httpGet<Lva[]>(`lva`);
  }

  public createLva(data: Lva): Observable<boolean> {
    return this._configService.httpCreate<boolean>(`lva`, data);
  }

  public updateLva(id: number, data: Lva): Observable<boolean> {
    return this._configService.httpUpdate<boolean>(`lva/${id}`, data);
  }

  public deleteLva(id: number): Observable<boolean> {
    return this._configService.httpDelete<boolean>(`lva/${id}`);
  }
}
