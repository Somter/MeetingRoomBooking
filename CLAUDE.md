# Сlaude Code Configuration & Project Guidelines

## Project Context
This is a Meeting Room Booking System built for a technical assessment. It includes concurrency control for bookings, real-time updates using SignalR, and role-based access.

## Tech Stack
- **Backend**: ASP.NET Core 8 Web API, Entity Framework Core, Azure SQL, Azure SignalR Service, xUnit.
- **Frontend**: React, TypeScript, Vite.

## Build & Run Commands
- Backend: `cd backend && dotnet run`
- Frontend: `cd frontend && npm install && npm run dev`
- Tests: `cd backend && dotnet test`

## Architectural & Development Rules
1. **Concurrency Control**: Strict requirement. We use Optimistic Concurrency with `RowVersion` in EF Core. No silent overwrites. A naive read-then-write approach is forbidden.
2. **Real-time**: Use Azure SignalR Service for propagating booking state changes instantly.
3. **Atomic Commits**: Commits must be small, focused, and contain a descriptive message explaining *what* changed and *why*.
4. **Code Quality**: Ensure clear separation of concerns. Use Dependency Injection. Code must be well-documented and production-ready.

## Custom Skills / Guidelines for Claude
- Always check for missing `await` in C# async methods.
- For React components, prefer functional components and Hooks.
- When generating tests for concurrency, simulate parallel HTTP requests or parallel Task executions.