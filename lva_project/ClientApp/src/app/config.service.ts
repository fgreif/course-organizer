import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  // _httpClient: HttpClient;

  constructor(
    private readonly httpClient: HttpClient) {
    // this._httpClient = httpClient;
   }

   
}
