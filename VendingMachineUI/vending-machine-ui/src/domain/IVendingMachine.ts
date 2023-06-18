export interface ICan {
  id: number,
  price: number,
  flavour: number,
  paymentType: number | 0
}

export default interface IVendingMachine {
  items: ICan[],
  numberOfItemSold: number,
  availableItems: number,
  cashAmount: number,
  cardAmount: number
}