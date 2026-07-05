export interface OrderRequest {

  items: OrderItemRequest[];

}

export interface OrderItemRequest {

  productId: string;

  quantity: number;

}