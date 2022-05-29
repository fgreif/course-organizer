import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ThisReceiver } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
@Injectable({
  // declares that this service should be created
  // by the root application injector.
  providedIn: 'root',
})
export class ConfigService {

  // _httpClient: HttpClient;
  private readonly _apiURL = '/api/';

  constructor(
    private readonly _http: HttpClient) {
    // this._httpClient = httpClient;
   }

   private _getReqOptionArgs(additionalOptions = {}): {headers: HttpHeaders; withCredentials: boolean} {
     const hdrs = new HttpHeaders();
     hdrs.append('Accept', 'application/json');
     return { ...{headers: hdrs, withCredentials: true}, ...additionalOptions};
   }

   public httpGet<Type>(url: string, params: string[] = []): Observable<Type> {
     const joinedParams = params.length > 0 ? '?' + params.join('&') : '';
     return this._http.get<Type>(this._apiURL + url + joinedParams, this._getReqOptionArgs());
   }

   public httpCreate<Type>(url: string, data: unknown): Observable<Type> {
     return this._http.post<Type>(this._apiURL + url, data, this._getReqOptionArgs());
   }

   public httpDelete<Type>(url: string): Observable<Type> {
     return this._http.delete<Type>(this._apiURL + url, this._getReqOptionArgs());
   }

   public httpUpdate<Type>(url: string, data: unknown): Observable<Type> {
     return this._http.put<Type>(this._apiURL + url, data, this._getReqOptionArgs());
   }

   public httpPatch<Type>(url: string): Observable<Type> {
     return this._http.patch<Type>(this._apiURL + url, this._getReqOptionArgs());
   }
}
