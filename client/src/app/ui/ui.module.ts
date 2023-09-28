import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './components/pages/shop/shop.component';
import { ProductComponent } from './components/product/product.component';
import { ProductFiltersComponent } from './components/filters/product-filters/product-filters.component';
import { ProductsGridComponent } from './components/grids/products-grid/products-grid.component';

@NgModule({
  declarations: [ShopComponent, ProductComponent, ProductFiltersComponent, ProductsGridComponent],
  imports: [CommonModule],
  exports: [ShopComponent],
})
export class UiModule {}
