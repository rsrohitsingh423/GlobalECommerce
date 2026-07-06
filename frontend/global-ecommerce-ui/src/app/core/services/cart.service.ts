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

//   readonly totalAmount = computed(() =>
//     this.subtotal() + this.shipping() + this.tax()
// );

  add(product: Product): void {

    this._cart.update(items => {

        const existing = items.find(x => x.productId === product.id);

        if (existing) {

            existing.quantity++;

            return [...items];

        }

        return [
            ...items,
            {
                productId: product.id,
                name: product.name,
                price: product.price,
                quantity: 1,
                imageUrl: product.imageUrl
            }
        ];

    });

}

decrease(productId: string): void {

    this._cart.update(items => {

        const item = items.find(x => x.productId === productId);

        if (!item) return items;

        item.quantity--;

        return items.filter(x => x.quantity > 0);
    });

}

increase(productId: string): void {

    this._cart.update(items => {

        const item = items.find(x => x.productId === productId);

        if (item) {

            item.quantity++;

        }

        return [...items];

    });

}

remove(productId: string): void {

    this._cart.update(items =>
        items.filter(x => x.productId !== productId)
    );

}

  clear(): void {
    this._cart.set([]);
  }

  getItems(): CartItem[] {
    return this._cart();
  }
readonly subtotal = computed(() =>
    this._cart().reduce(
        (sum, item) => sum + item.price * item.quantity,
        0
    )
);
shipping = computed(() =>

    this.subtotal() > 5000 ? 0 : 199

);
tax = computed(() =>

    this.subtotal() * 0.18

);
readonly totalAmount = computed(() =>
    this.subtotal() + this.shipping() + this.tax()
);
}