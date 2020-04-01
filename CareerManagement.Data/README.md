### 포트폴리오 기간 추가

```powershell
PS> dotnet ef migrations add Add_Period_Portfolio --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```

### 기간 추가

```powershell
PS> dotnet ef migrations add Add_Period --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```


### 링크 URL 추가

```powershell
PS> dotnet ef migrations add Add_Link_Url --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```


### 초기화

```powershell
PS> dotnet ef migrations add InitialCreate --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```
