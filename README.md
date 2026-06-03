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
### admin side screenshots
<img width="1148" height="1081" alt="Screenshot 2026-06-03 152315" src="https://github.com/user-attachments/assets/444100b3-8663-463a-9432-d0ee49e86d9b" />
<img width="1146" height="1082" alt="Screenshot 2026-06-03 152258" src="https://github.com/user-attachments/assets/0df41efd-c07f-4c7d-96d0-c90cd9166baa" />
<img width="1149" height="1081" alt="Screenshot 2026-06-03 152242" src="https://github.com/user-attachments/assets/7f197a21-2a2f-4b29-bf6f-aad77ad80726" />
<img width="1150" height="1081" alt="Screenshot 2026-06-03 152222" src="https://github.com/user-attachments/assets/e543efd9-6962-4698-aea9-b67f0f1b3e63" />
<img width="1147" height="1081" alt="Screenshot 2026-06-03 152212" src="https://github.com/user-attachments/assets/14190597-138a-4b5c-aaf9-3b6de6e13b38" />
<img width="1017" height="774" alt="Screenshot 2026-06-03 151756" src="https://github.com/user-attachments/assets/04f9c127-dc6d-4f65-91d5-1939805fe5ae" />
### user/student side screenshots
<img width="922" height="804" alt="Screenshot 2026-06-03 153455" src="https://github.com/user-attachments/assets/6a9a5961-36bf-4a64-ade4-3437deb1d1c5" />
<img width="921" height="806" alt="Screenshot 2026-06-03 153444" src="https://github.com/user-attachments/assets/138a7f35-81a8-4f71-b492-e4b0be2cfbf3" />
<img width="922" height="804" alt="Screenshot 2026-06-03 153430" src="https://github.com/user-attachments/assets/b1c2888d-666b-450a-9343-1f9ecd46945d" />
<img width="923" height="837" alt="Screenshot 2026-06-03 153055" src="https://github.com/user-attachments/assets/33256c58-7733-435d-a45a-dd309f38b03e" />
<img width="922" height="832" alt="Screenshot 2026-06-03 153045" src="https://github.com/user-attachments/assets/18bf9bfa-3b73-4335-88fb-7187a6a22184" />



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
