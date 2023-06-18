/**
 * Represents an individual can in the vending machine.
 */
export interface ICan {
  id: number;             // The unique identifier of the can.
  price: number;          // The price of the can.
  flavour: number;        // The flavour of the can.
  paymentType: number | 0;  // The supported payment type for the can (represented as a number or 0).
}

/**
 * Represents a vending machine.
 */
export default interface IVendingMachine {
  items: ICan[];          // The collection of cans available in the vending machine.
  numberOfItemSold: number;  // The total number of cans sold from the vending machine.
  availableItems: number;    // The number of cans currently available in the vending machine.
  cashAmount: number;        // The total cash amount stored in the vending machine.
  cardAmount: number;        // The total card payment amount stored in the vending machine.
}