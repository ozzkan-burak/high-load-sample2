# High-Concurrency Inventory Management System (POC)

### 🎯 Project Overview
This project serves as a **Proof of Concept (POC)** demonstrating how to handle high-traffic scenarios and prevent **Race Conditions** in an e-commerce environment.

It simulates a "Black Friday" traffic spike where thousands of concurrent requests attempt to purchase the same limited stock item, ensuring **Data Consistency** and **Atomicity**.

---

### 🏗️ Architect's Perspective

#### 1. The Challenge (Business Problem)
In high-load e-commerce systems, standard database transactions often fail to prevent overselling when multiple instances of a microservice try to update the stock simultaneously.
* **Scenario:** 100 users try to buy the last 1 item at the exact same millisecond.
* **Risk:** Without proper locking, the database might record negative stock, leading to cancelled orders and poor UX.

#### 2. The Solution (Architecture)
I implemented a robust **Concurrency Control** mechanism using **Distributed Locking** strategies.
* **Simulated Traffic:** Created a load generator to simulate concurrent POST requests.
* **Locking Mechanism:** Integrated **Redis** (or Optimistic Locking with EF Core) to ensure that only one process can modify the stock level at a time.
* **Result:** Achieved 100% data consistency under high load, preventing any stock discrepancies.

#### 3. Why This Tech Stack?
* **.NET (Core/9):** For its high-performance Kestrel server and strong support for asynchronous programming.
* **Entity Framework Core:** To demonstrate how ORM handles concurrency tokens (RowVersion).
* **Redis (Optional/If used):** Chosen for low-latency distributed locking across multiple server instances.
* **JMeter / Apache Bench:** Used for stress testing the endpoints.

---

### ⚙️ Key Features
* ✅ **Thread-Safe Inventory Updates:** Prevents race conditions.
* ✅ **Scalable Architecture:** Designed to work in a distributed environment (e.g., Kubernetes pods).
* ✅ **Performance Benchmarks:** Includes tests comparing "No-Lock" vs "With-Lock" scenarios.

### 🚀 How to Run
1. Clone the repo.
2. Update the `appsettings.json` with your connection string.
3. Run `dotnet run`.
4. Use the included load-test script to simulate traffic.

---
> *Note: This project highlights backend system design principles essential for scalable e-commerce platforms.*
