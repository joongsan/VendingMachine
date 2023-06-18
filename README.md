# Vending Machine

The Vending Machine project is a simple implementation of a vending machine system. It allows users to interact with the vending machine, make purchases, and manage the inventory.

## Assumptions
Assumptions are located within `Plan of attack.docx` file

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
5. Open your web browser and visit `http://localhost:5000` to access the application.

Vending Machine UI:
1. Navigate to the `VendingMachineUI` directory.
2. Install dependencies by running the following command: `npm install`
3. Start the development server: `npm run serve`

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
