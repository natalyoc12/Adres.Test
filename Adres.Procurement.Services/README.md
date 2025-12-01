```bash
cd Adres.Procurement.Infrastructure
```

```bash
dotnet ef migrations add CreateProcurementFile --startup-project ../Adres.Procurement.Api
```

```bash
dotnet ef database update --startup-project ../Adres.Procurement.Api
```
