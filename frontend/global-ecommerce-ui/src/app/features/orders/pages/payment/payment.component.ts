import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

import { CartService } from '../../../../core/services/cart.service';
import { CheckoutService } from '../../../../core/services/checkout.service';

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {

  readonly cart = inject(CartService);

  private readonly checkout = inject(CheckoutService);

  private readonly router = inject(Router);
  processing=false;

  pay(){

    this.processing=true;

    this.checkout.checkout();

}

  cancel()
  {
      this.router.navigate(['/cart']);
  }

}