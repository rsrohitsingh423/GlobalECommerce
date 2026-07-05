import { Routes } from '@angular/router';
import { ShellComponent } from './core/layouts/shell/shell.component';
import { ProductListComponent } from './features/catalog/pages/product-list.component';
import { CartComponent } from './features/orders/pages/cart/cart.component';
import { ConfirmationComponent } from './features/orders/pages/confirmation/confirmation.component';
import { MatIconModule } from '@angular/material/icon';
import { PaymentComponent } from './features/orders/pages/payment/payment.component';

export const routes: Routes = [

{
    path:'',
    component:ShellComponent,
    children:[
        {
            path:'',
            redirectTo:'catalog',
            pathMatch:'full'
        },
        {
            path:'catalog',
            component:ProductListComponent
        },
        {
            path:'cart',
            component:CartComponent
        },
        {
            path:'confirmation/:orderNumber',
            component:ConfirmationComponent
        },
        {
            path:'payment',
            component:PaymentComponent
        },
    ]
}
];