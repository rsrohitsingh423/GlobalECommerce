import { Routes } from '@angular/router';

import { ProductListComponent } from './features/catalog/pages/product-list.component';
import { CartComponent } from './features/orders/pages/cart/cart.component';
import { PaymentComponent } from './features/orders/pages/payment/payment.component';
import { ConfirmationComponent } from './features/orders/pages/confirmation/confirmation.component';

export const routes: Routes = [

  {
    path: '',
    redirectTo: 'catalog',
    pathMatch: 'full'
  },

  {
    path: 'catalog',
    component: ProductListComponent
  },

  {
    path: 'cart',
    component: CartComponent
  },

  {
    path: 'payment',
    component: PaymentComponent
  },

  {
    path: 'confirmation/:orderNumber',
    component: ConfirmationComponent
  },

  {
    path: '**',
    redirectTo: 'catalog'
  }

];