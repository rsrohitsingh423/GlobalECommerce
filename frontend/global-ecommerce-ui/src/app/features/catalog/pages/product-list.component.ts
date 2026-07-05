import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';
import { CartService } from '../../../core/services/cart.service';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {

  private service = inject(ProductService);
  private cartService = inject(CartService);

  products = signal<Product[]>([]);

  ngOnInit(): void {

    this.service.getProducts()

      .subscribe(x => this.products.set(x));

  }

  addToCart(product: Product) {

    this.cartService.add(product);

}

}