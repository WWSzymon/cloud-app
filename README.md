# Cloud Task Manager

**Autor:** Szymon Wójcik  
**Numer albumu:** 94570

## Repozytorium GitHub (Remote)
**Link do projektu:** [https://github.com/WWSzymon/cloud-app.git](https://github.com/WWSzymon/cloud-app.git)

## Deklaracja stosu technologicznego
- **Front-end:** [x] React + Vite
- **Back-end:** [x] .NET Web API
- **Baza danych:** [x] Azure SQL

## Mapowanie na usługi Azure (Architektura)

| Warstwa | Komponent Lokalny | Usługa Azure |
| :--- | :--- | :--- |
| **Prezentacja** | React 19 (Vite) | Azure Static Web Apps |
| **Aplikacja** | .NET 9 Web API | Azure App Service |
| **Dane** | SQL Server (Docker) | Azure SQL Database (Serverless) |

## Status Projektu

* [x] **Artefakt 1:** Architektura i struktura folderów.
* [x] **Artefakt 2:** Środowisko wielokontenerowe uruchomione lokalnie (Docker Compose).
* [ ] **Artefakt 3:** Działająca warstwa prezentacji (React + Vite).
* [ ] **Artefakt 4:** Działająca warstwa logiki backendu (.NET 9).