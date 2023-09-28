import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './components/pages/shop/shop.component';
import { ProductComponent } from './components/product/product.component';

@NgModule({
  declarations: [ShopComponent, ProductComponent],
  imports: [CommonModule],
  exports: [ShopComponent],
})
export class UiModule {}
