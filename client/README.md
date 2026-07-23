# AI Recruitment System

A full-stack recruitment management platform with role-based access for Administrators, Recruiters, and Candidates — covering organizations, departments, job postings, and applications.

## Tech Stack

**Backend**
- ASP.NET Core (.NET 9)
- Entity Framework Core
- Swashbuckle (Swagger / OpenAPI)
- BCrypt.Net-Next (password hashing)
- JWT authentication
- Policy-based authorization (`AdministratorOnly`, `AdministratorOrRecruiter`, etc.)
- SQL Server (database: `RecruitmentDB`)

**Frontend**
- Vue 3 (Composition API, `<script setup>`)
- Vite
- Vue Router
- Pinia
- Tailwind CSS
- Axios

## Project Structure

```
AI-Recruitment-System/
├── server/                 # ASP.NET Core backend
│   ├── Controllers/         # API controllers:
│   │                          #   AIMatchingController, ApplicationController, AuthController,
│   │                          #   CandidateController, DashboardController, DepartmentController,
│   │                          #   HomeController, InterviewController, JobController,
│   │                          #   OrganizationsController, ResumeController,
│   │                          #   ResumeParserController, UserController
│   ├── Data/                 # ApplicationDbContext, EF configuration
│   ├── DTOs/                  # Request/response data transfer objects
│   ├── Entities/               # EF Core entity models
│   ├── Features/                # Feature-organized services, interfaces, DTOs
│   ├── Repositories/           # Data access layer
│   └── Services/                # Business logic (e.g. AIMatchingService)
└── client/                 # Vue 3 frontend
    ├── src/
    │   ├── api/              # Axios API modules (organization, department, user, job...)
    │   ├── components/        # Shared components (StatCard, etc.)
    │   ├── views/              # Page views (admin/, recruiter/)
    │   └── router/               # Vue Router configuration
    └── vite.config.js
```

## Prerequisites

- .NET 9 SDK
- Node.js (LTS) and npm
- SQL Server (local or remote instance)

## Getting Started

### Backend (`server/`)

```bash
cd server
dotnet restore
dotnet build
dotnet run
```

By default the API runs on `https://localhost:5001` (confirm the actual port in `server/Properties/launchSettings.json`).

Update your connection string in `appsettings.json` (or `appsettings.Development.json`) to point at your SQL Server instance and the `RecruitmentDB` database (managed via SQL Server Management Studio), then apply migrations:

```bash
dotnet ef database update
```

### Frontend (`client/`)

```bash
cd client
npm install
npm run dev
```

The dev server will print the local URL (typically `http://localhost:5173`).

## Roles & Authorization

The system uses policy-based authorization with roles stored via `RoleId` on the `Users` table:

| RoleId | Role | Description |
|--------|------|--------------|
| 1 | Administrator | System Administrator |
| 2 | Recruiter | Recruitment Officer |
| 3 | Hiring Manager | Hiring Manager |
| 4 | Candidate | Job Applicant |

## API Testing

The API includes Swagger UI (via Swashbuckle) for interactive testing and documentation. After running the backend, navigate to the Swagger endpoint (typically `/swagger`) and use the **Authorize** button to supply a JWT bearer token for testing protected endpoints.

## Key Features

- Admin dashboard with live stats (users, active jobs, applications)
- Organization and department management
- Job posting creation with validation (required fields, salary range, closing date)
- Recruiter-only job management views
- Candidate profiles and job applications
- Interview scheduling
- Resume upload and parsing (`ResumeController`, `ResumeParserController`)
- AI-assisted candidate/job matching (`AIMatchingController`)
- JWT-based authentication (`/api/Auth/login`)

## Known Issues / Notes

- A few nullable-reference warnings remain in `ApplicationRepository.cs`
- `AIMatchingService.cs` has an async method with no current `await` call — placeholder for future AI-based candidate matching logic
- Ensure frontend API base URL matches the backend's actual running port/protocol to avoid SSL/connection errors

## License

Add your license of choice here (MIT, Apache 2.0, etc.).