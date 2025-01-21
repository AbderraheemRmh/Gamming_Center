# Gamming Center Application

A comprehensive **desktop application** designed for managing gaming centers efficiently. Built using **C#** and **SQLite**, this application provides features such as user management, product sales tracking, and time-based pricing.

## Features

- **User Authentication**:
  - Admin and Worker login.
  - Differentiated dashboards for Admins and Workers.

- **Product Management**:
  - Add, update, and track products.
  - Sales tracking with detailed records in the `Product_Cashier` table.

- **Time-Based Pricing**:
  - Calculate pricing for gaming sessions based on duration and category.
  - Integration with `Post`, `Type`, and `Category` tables for dynamic pricing.

- **Checkout Management**:
  - Real-time updates for total pricing.
  - Individual product tracking with quantity and price calculations.

- **Reporting**:
  - Filter sales by day, week, month, or custom date range.
  - Summarized sales data with worker and product details.

## Database Structure

### Tables

1. **Worker**
   - Stores user information with roles (Admin/Worker).

2. **Product**
   - Manages product details including price and stock.

3. **Product_Cashier**
   - Tracks product sales with issuer and date details.

4. **Post**
   - Handles gaming sessions with associated types and categories.

5. **Post_Cashier**
   - Records cashier transactions for gaming sessions with worker and session details.

6. **Type**
   - Defines session types with respective pricing for 2-player and 4-player modes.

7. **Category**
   - Organizes posts into categories.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/AbderraheemRmh/Gamming_Center.git
   ```
2. Ensure you have the following installed:
   - [.NET Framework or .NET Runtime](https://dotnet.microsoft.com/download)
   - SQLite (comes with the project)

3. Open the project in Visual Studio and build the solution.

4. Run the application to initialize the database and start using the system.

## Usage

- **Login**: Use the provided credentials or add users via the admin panel.
- **Add Products**: Navigate to the product management section to add or update products.
- **Sales Tracking**: Use the checkout panel to manage sales and generate reports.

## Screenshots
![6](https://github.com/user-attachments/assets/494f4572-c18b-49cc-a340-7687c2eb93da)
![5](https://github.com/user-attachments/assets/373228b4-00f5-45cd-b406-ab2d2fe3b286)
![4](https://github.com/user-attachments/assets/1b1348d4-0ff7-4ed6-80bf-08a070667202)
![3](https://github.com/user-attachments/assets/5ab545ec-2569-4586-8b12-118b5fd40a83)
![2](https://github.com/user-attachments/assets/2abd9dc9-a2db-4ae4-9cea-8e03745bbb93)
![1](https://github.com/user-attachments/assets/ccceb8ec-4c42-48f9-96ae-04e8e4df82a2)



## Contributing

Contributions are welcome! Feel free to fork this repository, create a new branch, and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Special thanks to all contributors and testers.


