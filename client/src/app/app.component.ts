import { HttpClient } from '@angular/common/http';
import { Product } from './models/product';
import { Component, OnInit } from '@angular/core';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  products: Product[] = [];

  constructor(private readonly httpClient: HttpClient) {}

  ngOnInit(): void {
    this.httpClient
      .get<Pagination<Product[]>>(
        'https://localhost:5001/api/products?pageSize=50'
      )
      .subscribe({
        next: (products) => (this.products = products.data),
        error: (error) => console.log(error),
      });
  }
}
