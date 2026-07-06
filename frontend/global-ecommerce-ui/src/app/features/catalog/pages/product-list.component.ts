import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';
import { CartService } from '../../../core/services/cart.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, MatCardModule,  MatButtonModule, MatSnackBarModule,    MatIconModule],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  private service = inject(ProductService);
  private cartService = inject(CartService);
  private readonly snackBar = inject(MatSnackBar);
  private readonly router = inject(Router);

  products = signal<Product[]>([]);

  ngOnInit(): void {

    this.service.getProducts()

      .subscribe(x => this.products.set(x));

  }

addToCart(product: Product): void {

    this.cartService.add(product);

    const snackBarRef = this.snackBar.open(
    `✅ ${product.name} added to cart`,
    'View Cart',
    {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
    });
    snackBarRef.onAction().subscribe(() => {
    this.router.navigate(['/cart']);
});
}

}