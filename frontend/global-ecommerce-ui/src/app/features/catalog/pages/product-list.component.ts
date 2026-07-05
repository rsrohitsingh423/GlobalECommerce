import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';
import { CartService } from '../../../core/services/cart.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, MatCardModule,  MatButtonModule, MatSnackBarModule],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  private service = inject(ProductService);
  private cartService = inject(CartService);
  private readonly snackBar = inject(MatSnackBar);

  products = signal<Product[]>([]);

  ngOnInit(): void {

    this.service.getProducts()

      .subscribe(x => this.products.set(x));

  }

addToCart(product: Product): void {

    this.cartService.add(product);

    this.snackBar.open(
        `✅ ${product.name} added to cart`,
        'Close',
        {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top'
        });

}

}