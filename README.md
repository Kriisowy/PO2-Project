# PO2-PROJECT

# 🎣 1. System Zarządzania Klubem Wędkarskim
Aplikacja desktopowa do kompleksowego zarządzania klubem wędkarskim. Umożliwia rejestrację członków, organizację zawodów oraz rejestr połowów

Funkcje:

Rejestracja i zarządzanie członkami (dane osobowe, opłaty, licencje)

Organizacja zawodów wędkarskich (zapisy, wyniki, klasyfikacje)

Rejestr połowów (data, miejsce, gatunek, waga)

# 1. Członkowie Klubu
Funkcje:

Dodawanie/edycja/usuwanie danych członków

Historia składek i licencji

Przegląd aktywności (udział w zawodach, połowy)

Wyszukiwanie i filtrowanie po nazwisku, statusie członkostwa

Widok:
![alt text](image-1.png)

# 2. Zawody Wędkarskie
Funkcje:

Tworzenie wydarzeń (nazwa, data, typ łowiska)

Widok:
![alt text](image-2.png)

# 3. Wyniki Zawodów Wędkarskich
Funkcje:

Rejestrowanie wyników (wędkarz, ilość, gatunek, masa)

Widok:
![alt text](image-3.png)

# 4. Rejestr Połowów
Funkcje:

Dodawanie połowu 

Informacje o gatunku, lokalizacji, dacie

Widok:
![alt text](image-4.png)

# 🗃️ Propozycja Bazy Danych (schemat)
Poniżej prezentuję uproszczony schemat relacyjnej bazy danych:

# 🔗 Tabele i relacje:

Member

├── Id (PK)

├── FirstName

├── LastName

├── BirthDate

├── Phone

├── Email

├── JoinDate

├── IsActive

├── LicenseValidUntil

└── MembershipFeePaid (bool)

FishingCompetition

├── Id (PK)

├── Name

├── Date

├── Location

└── CompetitionType (Open / Klubowe)

CompetitionResult

├── Id (PK)

├── MemberId (FK)

├── CompetitionId (FK)

├── FishType

├── Weight

└── Place

FishingLog

├── Id (PK)

├── MemberId (FK)

├── Date

├── Location

├── FishType

└── Weight
