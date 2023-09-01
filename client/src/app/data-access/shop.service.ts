import { Product } from './../models/product';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pagination } from '../models/pagination';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  private baseUrl = 'https://localhost:5001/api/';

  constructor(private readonly httpClient: HttpClient) {}

  getProducts(): Observable<Pagination<Product[]>> {
    return this.httpClient.get<Pagination<Product[]>>(
      this.baseUrl + 'products?pageSize=6'
    );
  }
}
