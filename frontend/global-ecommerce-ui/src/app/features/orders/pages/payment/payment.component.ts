import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { CartService } from '../../../../core/services/cart.service';
import { CheckoutService } from '../../../../core/services/checkout.service';
import { PaymentApiService } from '../../../../core/api/payment-api.service';

@Component({
    selector: 'app-payment',
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatCardModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule,
        MatProgressSpinnerModule
    ],
    templateUrl: './payment.component.html',
    styleUrls: ['./payment.component.css']
})
export class PaymentComponent {

    private readonly fb = inject(FormBuilder);

    private readonly paymentApi = inject(PaymentApiService);

    private readonly checkout = inject(CheckoutService);

    readonly cart = inject(CartService);

    processing = false;

    paymentForm = this.fb.group({

        cardHolderName: ['', Validators.required],

        cardNumber: [
            '',
            [
                Validators.required,
                Validators.minLength(16),
                Validators.maxLength(16)
            ]
        ],

        expiryMonth: ['', Validators.required],

        expiryYear: ['', Validators.required],

        cvv: [
            '',
            [
                Validators.required,
                Validators.minLength(3),
                Validators.maxLength(4)
            ]
        ]

    });

    pay() {

        if (this.paymentForm.invalid) {

            this.paymentForm.markAllAsTouched();

            return;

        }

        this.processing = true;

        const request = {

            ...this.paymentForm.value,

            amount: this.cart.totalAmount()

        };

        this.paymentApi.process(request)
            .subscribe({

                next: () => {

                    this.checkout.checkout();

                },

                error: () => {

                    this.processing = false;

                    alert("Payment Failed");

                }

            });

    }

}