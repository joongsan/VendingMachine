# Vending Machine

The Vending Machine project is a simple implementation of a vending machine system. It allows users to interact with the vending machine, make purchases, and manage the inventory.

## Assumptions

1. The vending machine supports only a fixed number of flavors for the cans.

· This assumption is based on the statement that the vending machine can stock up to 10 different flavors of cans. It implies that the number of flavors is fixed and cannot be dynamically changed during runtime.

2. All cans in the vending machine have the same price.

· This assumption is based on the statement that the value of cans may be decided by you at design time. It suggests that all cans in the vending machine have a uniform price and do not vary based on flavor or other factors.

3. The GUI will display real-time information about the vending machine's state.

· This assumption is inferred from the requirement to visually display the number of available cans, the money held in the machine, and the credit card payments. It implies that the GUI should reflect the current state of the vending machine, including any changes made during transactions or restocking.

4. Cash and credit card payments are made with the correct change.

· This assumption is mentioned in the requirement that states the vending machine expects cash and card payments to be made with the correct change. It suggests that the system does not handle providing change or handling scenarios where incorrect payment amounts are made.

5. The vending machine's data is stored in memory during runtime and not persisted.

· This assumption is based on the statement that the information about the number of cans available, the money held in the machine, and credit card payments does not necessarily need to be persisted. It implies that the data is maintained in memory for the duration of the program's execution.

## Features

- Initialize the vending machine with predefined items and quantities.
- Purchase items from the vending machine using cash or card payment.
- Keep track of the number of items sold and available inventory.
- Restock the vending machine when the inventory runs out.

## Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core (for data persistence)
- Vue.js: A progressive JavaScript framework for building user interfaces.
- Vuetify: A Material Design component framework for Vue.js.
- Vuex: A state management pattern and library for Vue.js applications.
- Axios: A promise-based HTTP client for making API requests.

## Getting Started

To run the Vending Machine project locally, follow these steps:

- Clone the repository: `git clone https://github.com/joongsan/VendingMachine.git`

Vending Machine API:
1. Navigate to the project directory: `cd VendingMachine`
2. Install the necessary dependencies: `dotnet restore`
3. Build the project: `dotnet build`
4. Run the application: `dotnet run`
5. Open your web browser and visit `<your localhost>` to access the application.

Vending Machine UI:
1. Navigate to the `VendingMachineUI` directory.
2. Install dependencies by running the following command: `npm install`
3. Install axios dependencies by running the following command: `npm install axios`
4. Start the development server: `npm run serve`
- Make sure to update base URL to locally running API endpoint. <strong>UDATE FOLLOWING CODE</strong> `const baseURL = 'https://localhost:7255/';`

## Project Structure

The project follows the following directory structure:

- `VendingMachine.Application` - Contains the application logic and models.
- `VendingMachine.Domain` - Contains the domain models and interfaces.
- `VendingMachine.Infrastructure` - Contains the data access layer and database context.
- `VendingMachine.Controllers` - Contains the controllers.
- `VendingMachine.VendingMachineUI` - Contains the web application and views

### Endpoints

- `GET /`: Retrieves the current state of the vending machine.
- `POST /`: Performs a transaction for the selected item and payment type.
