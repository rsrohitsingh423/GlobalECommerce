import { Injectable, computed, signal } from '@angular/core';
import { CartItem } from '../../features/catalog/models/cart-item';
import { Product } from '../../features/catalog/models/product';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private readonly _cart = signal<CartItem[]>([]);

  readonly cart = this._cart.asReadonly();

  readonly itemCount = computed(() =>
    this._cart().reduce((count, item) => count + item.quantity, 0)
  );

  readonly totalAmount = computed(() =>
    this._cart().reduce((total, item) =>
      total + (item.product.price * item.quantity), 0)
  );

  add(product: Product): void {

    const cart = [...this._cart()];

    const existing = cart.find(x => x.product.id === product.id);

    if (existing) {
      existing.quantity++;
    } else {
      cart.push({
        product,
        quantity: 1
      });
    }

    this._cart.set(cart);
  }

  decrease(productId: string): void {

    const cart = [...this._cart()];

    const item = cart.find(x => x.product.id === productId);

    if (!item)
      return;

    item.quantity--;

    if (item.quantity <= 0) {
      this.remove(productId);
      return;
    }

    this._cart.set(cart);
  }

  increase(productId: string): void {

    const cart = [...this._cart()];

    const item = cart.find(x => x.product.id === productId);

    if (!item)
      return;

    item.quantity++;

    this._cart.set(cart);
  }

  remove(productId: string): void {

    this._cart.update(items =>
      items.filter(x => x.product.id !== productId)
    );

  }

  clear(): void {
    this._cart.set([]);
  }

  getItems(): CartItem[] {
    return this._cart();
  }
}