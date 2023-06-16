export interface ICan {
  id: number,
  price: number,
  flavour: number
}

export default interface IVendingMachine {
  items: ICan[],
  numberOfItemSold: number,
  availableItems: number,
  cashAmount: number,
  cardAmount: number
}