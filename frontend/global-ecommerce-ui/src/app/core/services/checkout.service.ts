import { Injectable, inject } from '@angular/core';
import { Router } from '@angular/router';

import { CartService } from './cart.service';
import { OrderApiService } from '../api/order-api.service';

import { OrderRequest } from '../../features/orders/models/order-request';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  private readonly cartService = inject(CartService);
  private readonly orderApi = inject(OrderApiService);
  private readonly router = inject(Router);

  checkout(): void {

    const cart = this.cartService.getItems();

    const request: OrderRequest = {

      items: cart.map(item => ({

        productId: item.productId,

        quantity: item.quantity

      }))

    };

    setTimeout(() => {

    this.orderApi.createOrder(request).subscribe({

        next: response => {

            this.cartService.clear();

            this.router.navigate([
                '/confirmation',
                response.orderNumber
            ]);

        },

        error: err => {

            console.error(err);

            alert('Payment Failed');

        }

    });

},2000);
    // this.orderApi.createOrder(request).subscribe({

    //   next: response => {

    //     this.cartService.clear();

    //     this.router.navigate([
    //       '/confirmation',
    //       response.orderNumber
    //     ]);

    //   },

    //   error: err => {

    //     console.error(err);

    //     alert("Unable to place order.");

    //   }

    // });

  }

}