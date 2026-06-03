# EquipTrack — Laboratory Equipment Management System

A full-featured laboratory equipment management system built with C# WinForms and MySQL, designed for schools and institutions to manage equipment borrowing, reservations, and inventory.

## Features

### Admin Features
- Dashboard with real-time statistics — total equipment, available, borrowed, overdue
- Equipment management — add, edit, delete with course-based permissions
- User management — register and manage students and staff
- Lab borrow slip system — full approval workflow (Pending → Approved → Released → Returned)
- Return approval system — approve or decline return requests
- Analytics charts — most borrowed equipment and borrowing trends
- Course-based filtering — filter equipment by course (CPE, EE, BSN)
- Sales and borrowing reports — weekly, monthly, yearly
- Real-time search across all modules

### Student Features
- Browse available equipment filtered by course
- Submit lab borrow slips with group members and equipment list
- Track borrowing status and history
- Request returns
- View personal borrowing dashboard
- Cancel pending slips

## Technologies Used

- Language: C#
- Framework: .NET WinForms
- Database: MySQL via MySql.Data connector
- Charts: Windows Forms DataVisualization
- IDE: Visual Studio

## Database Setup

1. Install MySQL Server
2. Create a new database
3. Update the connection string in `DATABASE.cs`
4. Run the provided SQL schema to create tables

## How To Run

1. Clone the repository
2. Set up MySQL database (see above)
3. Open the `.sln` file in Visual Studio
4. Restore NuGet packages
5. Build and run the project
6. Login as Admin or Student

## Screenshots

> Add screenshots of your app here

## Architecture

```
EquipTrack/
├── Models/          — Data models (Equipment, User, BorrowRecord)
├── Forms/           — WinForms UI (adminform, userform, loginform)
├── Functions/       — Business logic
├── file_opening/    — File handlers
└── DATABASE.cs      — MySQL connection manager
```

## Author

**Vince Gabrielle Milos**
BS Computer Engineering — Cebu Institute of Technology

> Built independently as a personal project to demonstrate full-stack desktop application development with C# and MySQL.
