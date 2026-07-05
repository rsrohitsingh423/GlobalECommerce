import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-confirmation',
  standalone: true,
  templateUrl: './confirmation.component.html'
})
export class ConfirmationComponent {

  readonly route = inject(ActivatedRoute);

  orderNumber = this.route.snapshot.paramMap.get("orderNumber");

}