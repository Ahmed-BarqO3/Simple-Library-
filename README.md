# Simple Library Management System

## Project Overview
This project outlines the requirements for a simple Library Management System. The system will handle book management, user management, borrowing and returns, holds and reservations, and fine management.

## Database Implementation

This project uses **SQL Server** to manage the library's database operations. The following Stored Procedures and Triggers:

### Stored Procedures
- **Stored procedures** are used to encapsulate and execute queries and operations within the database efficiently.
   They help in maintaining data integrity and improving performance.

### Triggers
- **Triggers** are implemented to automatically execute predefined actions in response to certain events on a particular table.
   For instance, triggers are used to update book availability status upon borrowing or returning, and to calculate fines for overdue books.

## Features

### 1. Book Management
- **Store and Manage Book Information:**
  - The system will store detailed information about each book and manage its records.
  
- **Track Availability Status:**
  - The system will track whether each book copy is available for borrowing or currently checked out.
  
- **Manage Multiple Copies:**
  - The system will handle multiple copies of the same book, assigning unique identifiers to each copy.

### 2. User Management
- **Maintain User Records:**
  - The system will maintain comprehensive records of library users, including their personal details and library card numbers.

### 3. Borrowing and Returns
- **Enable Book Borrowing:**
  - The system will allow users to borrow book copies from the library.
  
- **Track Borrowing Records:**
  - The system will keep detailed records of all borrowed books, including information about the borrowing user and due dates.
  
- **Handle Returns:**
  - The system will process book returns and update the availability status of the returned book copies.
  
### 4. Holds and Reservations
- **Place Holds or Reservations:**
  - The system will enable users to place holds or reservations on book copies that are currently checked out.
  
- **Manage Reservation Order:**
  - The system will ensure that reservations are managed fairly and in the correct order.

### 5. Fine Management
- **Calculate and Manage Fines:**
- The system will calculate late return fines and manage these records.
  

  
