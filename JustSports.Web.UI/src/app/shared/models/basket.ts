export interface IBasket {
    //customerId: number;
    items: IBasketItem[];
  }

  export interface IBasketItem {
    id: number;
    basketId: number;
    productId: number;
    purchasePrice: number;
    quantity: number;
  }

  export class Basket implements IBasket {
    //customerId: number;
    items: IBasketItem[] = [];
   }