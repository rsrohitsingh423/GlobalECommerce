import { Injectable, computed, signal } from '@angular/core';
import { CartItem } from '../../features/catalog/models/cart-item';
import { Product } from '../../features/catalog/models/product';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  // Private state
  private readonly _cart = signal<CartItem[]>([]);

  // Readonly signal exposed to UI
  readonly cart = this._cart.asReadonly();

  // Computed signals
  readonly itemCount = computed(() =>
    this._cart().reduce((total, item) => total + item.quantity, 0)
  );

  readonly total = computed(() =>
    this._cart().reduce(
      (total, item) => total + (item.product.price * item.quantity),
      0
    )
  );

  add(product: Product): void {

    const cart = [...this._cart()];

    const existing = cart.find(x => x.product.id === product.id);

    if (existing) {
      existing.quantity++;
    }
    else {
      cart.push({
        product,
        quantity: 1
      });
    }

    this._cart.set(cart);
  }

  remove(productId: string): void {

    const cart = [...this._cart()];

    const item = cart.find(x => x.product.id === productId);

    if (!item)
      return;

    item.quantity--;

    if (item.quantity <= 0) {

      this._cart.set(
        cart.filter(x => x.product.id !== productId)
      );

      return;
    }

    this._cart.set(cart);
  }

  clear(): void {
    this._cart.set([]);
  }
}