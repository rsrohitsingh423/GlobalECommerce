import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

import { OrderRequest } from '../../features/orders/models/order-request';
import { OrderResponse } from '../../features/orders/models/order-response';

@Injectable({
  providedIn: 'root'
})
export class OrderApiService {

  private readonly http = inject(HttpClient);

  private readonly baseUrl = `${environment.apiUrl}/orders`;

  createOrder(request: OrderRequest): Observable<OrderResponse> {

    return this.http.post<OrderResponse>(
      this.baseUrl,
      request
    );

  }

}