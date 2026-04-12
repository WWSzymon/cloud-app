# Cloud Task Manager

**Autor:** Szymon Wójcik  
**Numer albumu:** 94570  

## Repozytorium GitHub (Remote)
**Link do projektu:** [https://github.com/WWSzymon/cloud-app.git](https://github.com/WWSzymon/cloud-app.git)

## Deklaracja stosu technologicznego
- **Front-end:** [x] React 19 + Vite
- **Back-end:** [x] .NET 9 Web API
- **Baza danych:** [x] Azure SQL
- **Zarządzanie sekretami:** [x] Azure Key Vault

## Mapowanie na usługi Azure (Architektura)

| Warstwa | Komponent Lokalny | Usługa Azure |
| :--- | :--- | :--- |
| **Prezentacja** | React 19 (Vite) | Azure Static Web Apps |
| **Aplikacja** | .NET 9 Web API | Azure App Service (Linux) |
| **Dane** | SQL Server (Docker) | Azure SQL Database (Serverless) |
| **Bezpieczeństwo** | Pliki appsettings.json | **Azure Key Vault + Managed Identity** |

## Linki do wdrożonej aplikacji
- **Frontend (UI):** [https://zealous-mud-06ab46e1e.4.azurestaticapps.net](https://zealous-mud-06ab46e1e.4.azurestaticapps.net)
- **Backend (API/Swagger):** [https://cloud-task-manager-api-v2-94570.azurewebsites.net](https://cloud-task-manager-api-v2-94570.azurewebsites.net)

## Bezpieczeństwo i Zarządzanie Sekretami (Artefakt 7)
W ramach zabezpieczania aplikacji wdrożono następujące mechanizmy:
- **Eliminacja sekretów z kodu:** Usunięto Connection Stringi z plików konfiguracyjnych i kodu źródłowego.
- **Azure Key Vault:** Wrażliwe dane dostępowe do bazy danych są przechowywane w bezpiecznym magazynie `kv-cloud-task-menager`.
- **Managed Identity:** Wykorzystano Tożsamość Zarządzaną (System-Assigned) przypisaną do usługi App Service, co umożliwia bezhasłową autoryzację aplikacji w Magazynie Kluczy.
- **RBAC:** Nadano uprawnienia "Key Vault Secrets User" dla tożsamości aplikacji, co gwarantuje dostęp zgodnie z zasadą najmniejszych uprawnień.

## Status Projektu
- [x] **Artefakt 1:** Architektura i struktura folderów.
- [x] **Artefakt 2:** Środowisko wielokontenerowe uruchomione lokalnie (Docker Compose).
- [x] **Artefakt 3:** Działająca warstwa prezentacji (React + Vite).
- [x] **Artefakt 4:** Działająca warstwa logiki backendu (.NET 9).
- [x] **Artefakt 5:** Stabilność (DTO) i trwałość (Volumes) aplikacji.
- [x] **Artefakt 6:** Pełna integracja i wdrożenie aplikacji w chmurze Microsoft Azure.
- [x] **Artefakt 7:** Bezpieczeństwo i eliminacja sekretów (Key Vault + Managed Identity).