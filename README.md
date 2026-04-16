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
- **Eliminacja sekretów z kodu:** Connection String został przeniesiony do bezpiecznej konfiguracji chmurowej.
- **Azure Key Vault:** Wrażliwe dane dostępowe są przechowywane w magazynie `kv-cloud-task-manager`.
- **Managed Identity & Access Policies:** Wykorzystano Tożsamość Zarządzaną przypisaną do App Service. W celu zapewnienia natychmiastowego dostępu zastosowano model **Vault Access Policies**, nadając aplikacji uprawnienia "Get" i "List".
- **Zabezpieczenie Firewall:** Baza Azure SQL dopuszcza ruch wyłącznie z autoryzowanych usług Azure.

## Testy i CI/CD (Artefakt 8)
- **Testy Jednostkowe:** Wdrożono testy w frameworku xUnit weryfikujące poprawność logiki modeli danych.
- **GitHub Actions:** Skonfigurowano potok CI/CD, który automatycznie buduje aplikację, uruchamia testy i wdraża nową wersję na Azure App Service po każdym zatwierdzeniu zmian w gałęzi `main`.
- **Automatyczna Inicjalizacja:** Zaimplementowano mechanizm `EnsureCreated()`, który dba o spójność schematu bazy danych przy każdym starcie aplikacji w chmurze.

## Status Projektu
- [x] **Artefakt 1:** Architektura i struktura folderów.
- [x] **Artefakt 2:** Środowisko wielokontenerowe uruchomione lokalnie.
- [x] **Artefakt 3:** Działająca warstwa prezentacji (React + Vite).
- [x] **Artefakt 4:** Działająca warstwa logiki backendu (.NET 9).
- [x] **Artefakt 5:** Stabilność (DTO) i trwałość (Volumes) aplikacji.
- [x] **Artefakt 6:** Pełna integracja i wdrożenie aplikacji w chmurze Azure.
- [x] **Artefakt 7:** Bezpieczeństwo i eliminacja sekretów (Key Vault + Managed Identity).
- [x] **Artefakt 8:** Testy automatyczne i ciągłe wdrożenie (CI/CD).