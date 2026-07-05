import { Routes } from '@angular/router';
import { ShellComponent } from './core/layouts/shell/shell.component';
import { ProductListComponent } from './features/catalog/pages/product-list.component';
import { CartComponent } from './features/orders/pages/cart/cart.component';

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
        }
    ]
}
];