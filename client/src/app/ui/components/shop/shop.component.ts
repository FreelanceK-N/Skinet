import { Component, OnInit } from '@angular/core';
import { ShopService } from 'src/app/data-access/shop.service';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products: Product[] = [];

  constructor(private readonly shopService: ShopService) {}

  ngOnInit(): void {
    this.shopService.getProducts().subscribe({
      next: (result) => (this.products = result.data),
      error: (error) => console.log(error),
    });
  }
}
