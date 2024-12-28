# Scrum Poker API  

A robust backend for the Scrum Poker application, built with **.NET** and following the **CQRS** pattern with **Mediator Design Pattern** for clear separation of concerns. The API enables room creation, user management, and real-time communication with **SignalR**.  

---

## Features  

### 🌟 Core Functionalities  
- **CQRS with Mediator Pattern:**  
  - Commands and queries are separated to ensure a clean architecture.  
  - Decoupled communication between components for improved scalability.  

- **Database Design:**  
  - **PostgreSQL** as the database for high performance and scalability.  
  - Dynamic mapping using **Entity Framework Core**.  
  - LINQ Query Syntax for efficient and readable database queries.  

- **Real-Time Communication:**  
  - SignalR integration for live updates and notifications.  
  - Room and user synchronization across clients.  

---

## 📊 Database Schema  

### Tables  
1. **Room:**  
   - Represents a session where users can join and vote.  
   - Key columns:  
     - `RoomName`: Name of the room.  
     - `RoomUniqId`: Unique identifier for room access.  
     - `EstimationMethodId`: Specifies the estimation method (e.g., Fibonacci, T-shirt sizes).  

2. **TemporaryUser:**  
   - Stores details of temporary users who join a room.  
   - Key columns:  
     - `SessionId`: Unique session ID for the temporary user.  
     - `Username`: Name of the user.  

3. **UserRoom:**  
   - Links users to rooms, including additional information like their role and votes.  
   - Key columns:  
     - `IsHost`: Indicates if the user is the host of the room.  
     - `UserVote`: Stores the user's vote in the session.  

---

## 🔄 SignalR Integration  

### Key Functions  
1. **User Joined:**  
   - Adds a user to the room and updates the active user list for all clients.  

2. **User Left:**  
   - Removes the user from the room and updates other clients.  

3. **Show Estimate Notify:**  
   - Notifies participants when voting results are visible.  

---

## 🚀 Technology Stack  

| Technology               | Usage                                   |
|---------------------------|-----------------------------------------|
| **.NET 8**                | API development                        |
| **Entity Framework Core** | ORM for database operations            |
| **PostgreSQL**            | Database for storing persistent data   |
| **SignalR**               | Real-time communication framework      |
| **CQRS**                  | Clean separation of commands & queries |


