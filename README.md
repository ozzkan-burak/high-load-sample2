# Microservices Flash Sale System (POC)

### 🎯 Project Overview
This project simulates a real-world **"Flash Sale"** scenario to demonstrate **Data Consistency** and **Concurrency Control** within a distributed microservices architecture.

The system handles a high-traffic campaign where 20 concurrent users compete for a limited stock of 5 items, successfully preventing overselling through robust architectural patterns.

---

### 🏗️ Architect's Perspective

#### 1. System Design & Polyglot Persistence
I designed the system using a **Microservices Architecture**, selecting the best-fit database for each specific domain (Polyglot Persistence):

* **🛒 Product Service (MongoDB):** Chosen for high read performance and flexible schema, ideal for product catalogs where read operations heavily outnumber writes.
* **📦 Stock Service (PostgreSQL):** Chosen for its strong ACID compliance and relational integrity, ensuring strictly accurate inventory tracking.
* **📝 Order Service (PostgreSQL):** Handles transactional order data with relational consistency.

#### 2. The Challenge: "The Flash Sale Race"
* **Scenario:** A highly discounted product with only **5 units** in stock.
* **Load Test:** Simulating **20 Concurrent Virtual Users (VUs)** attempting to purchase simultaneously using **k6**.
* **Risk:** Race conditions causing "Overselling" (selling more items than available stock).

#### 3. The Solution & Results
Implemented strict concurrency controls (Optimistic/Pessimistic locking strategies) within the transactional boundaries of the Stock Service.

* **Test Result:** Under the heavy load of 20 concurrent requests for 5 items, the system successfully processed exactly **5 orders** and rejected the remaining 15 with appropriate "Out of Stock" messages.
* **Consistency:** 100% Data Integrity achieved.

---

### 🛠️ Tech Stack

| Domain | Technology | Usage |
| :--- | :--- | :--- |
| **Backend Framework** | **.NET (Core/9)** | High-performance microservices |
| **NoSQL Database** | **MongoDB** | Product Catalog (Read-heavy) |
| **Relational Database** | **PostgreSQL** | Stock & Order Management (Transactional) |
| **Load Testing** | **k6** | Simulating concurrent traffic & stress testing |
| **Containerization** | **Docker** | Service orchestration |

---

### 🚧 Roadmap: Architecture Evolution (Next Steps)
To further decouple the services and improve system resilience, the next architectural phase involves:
* **Event-Driven Architecture:** Integrating **RabbitMQ**.
* **Async Processing:** Moving order placement to a queue-based system to handle traffic spikes more efficiently (削峰 - Peak Shaving).

---

### 🚀 How to Run the Load Test
1.  Spin up the environment: `docker-compose up -d`
2.  Run the k6 script:
    ```bash
    k6 run load-tests/flash-sale-simulation.js
    ```
3.  Observe the database logs to verify exactly 5 items were deducted.
