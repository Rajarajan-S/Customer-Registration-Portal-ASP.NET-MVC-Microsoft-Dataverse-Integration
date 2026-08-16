# Customer-Registration-Portal-ASP.NET-MVC-Microsoft-Dataverse-Integration
An end-to-end integration project demonstrating how an external ASP.NET MVC application integrates with Microsoft Dataverse using ServiceClient and a Dynamics 365 plugin to create Contacts with duplicate email validation.

Architecture
Customer Registration Website
        │
        ▼
ASP.NET MVC 5 (.NET Framework 4.7.2)
        │
        ▼
Microsoft Dataverse (Web Registration)
        │
        ▼
Create Plugin
        │
        ▼
Duplicate Email Validation
   ├── Duplicate → Return Error
   └── New Email → Create Contact

Technologies Used
•	ASP.NET MVC 5
•	C#
•	Microsoft Dataverse
•	Power Apps Developer Plan
•	Model-Driven App
•	Microsoft Entra ID App Registration
•	Microsoft.PowerPlatform.Dataverse.Client
•	Dynamics 365 Plugin
•	Visual Studio

