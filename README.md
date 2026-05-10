# ReadingNook

ReadingNook är ett ASP.NET Core Web API som är byggt för att hantera böcker man läst och spåra vart man är i läsningen genom "sessions". Projektet använder sig av Clean Architecture för att säkerställa hög testbarhet och låg koppling mellan lager. Det följer även CQRS och har säkerhet med JWT.
### Lagerstruktur
**Domain**: Innehåller entiteter, interfaces och Enums. Det har inga externa beroenden.
**Application**: Innehåller affärslogik, CQRS-kommandon och frågor, handlers, DTOs samt valideringslogik via FluentValidation.
**Infrastructure**: Hanterar databaskonfiguration, implementationer av repositories, SQL Server-integration via EF Core samt JWT-tjänster.
**API**: Aggerar ingångsport för HTTP-anrop med controllers som kommunicerar via MediatR.

## Mönster, Teknologier, Bibliotek & GitHub
**CQRS med MediatR**: Separerar läs- och skrivoperationer för ökad tydlighet och skalbarhet.
**Repository Pattern**: Gör applikationen mindre beroende.
**Pipeline Behaviors**: För automatisk validering av inkommande requests innan de når sin handler.
**Framework**: .NET 10
**ORM**: Entity Framework Core med SQL Server.
**Meddelandehantering**: MediatR
**Validering**: FluentValidation
**Säkerhet**: JWT (JSON Web Tokens) med RBAC (Role-Based Access Control). Systemet använder JWT Bearer-tokens för autentisering. I mina controllers valde jag att använda [Authorize(Roles = "User,Admin")] för att visa på hur man kan skriva för att [Authorize] för en eller vissa användare, dock har jag vetskapen att i mitt project har [Authorize(Roles = "User,Admin")] och [Authorize] exakt samma funktion då jag bara har två användar roller just nu, men då detta är ett API för en app där User skall ha full åtkomst kändes det inte rätt att bara skriva [Authorize(Roles = "Admin")], vilket resulterar i att enbart Admin kommer ha åtkomst till att använda just den endpointen.
**Mapping**: Mapster (Se "Varför Mapster istället för AutoMapper")
**Branch Protection**: main-branchen är skyddad från direkta pushar, all kod måste commitas till main från en branch med en Pull Request.
**Commits**: Projektet har tydliga beskrivande commit-meddelanden.

### Varför Mapster istället för AutoMapper
I detta projekt har **Mapster** valts som objektmappningsverktyg istället för AutoMapper. Beslutet grundas på Mapsters höga prestanda och det faktum att nyare versioner av AutoMapper har infört licensförändringar/kontokrav som gör det jobbigare att använda. Mapster erbjuder enligt mig likvärdig  funktionalitet för det som behövs inom mappnign i mitt projekt.


## Kom igång (hur man använder appen)

### Du behöver dessa program installerade:
* .NET 10 SDK
* SQL Server / SQL Express

### Installation av API
1.  Klona ner repot.
2.  Uppdatera connection string i appsettings.json vid behov till den server du har.
3.  Kör "dotnet ef database update" i Infrastructure-projektet för att skapa databasen och köra migrations.
4.  Starta projektet via ReadingNook.API.

### Tack för att ni kikar på mitt ReadingNook projekt!
