### 기술 분류 명칭 수정

```powershell
PS> dotnet ef migrations add ModifyNameOnSkill --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```

### 기술 항목 설명 추가

```powershell
PS> dotnet ef migrations add AddDescriptionOnSkillItem --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```

### 기술 분류 명칭 추가

```powershell
PS> dotnet ef migrations add AddNameOnSkill --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```

### 포트폴리오 태그 이름 변경

```powershell
PS> dotnet ef migrations add RenamePortfolioTag --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```

### 식별자 자동 생성

```powershell
PS> dotnet ef migrations add IdGenerateOnAdd --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```



### 초기화

```powershell
PS> dotnet ef migrations add InitialCreate --context DataContext --startup-project ../CareerManagement.Web/CareerManagement.Web.csproj --project ../CareerManagement.Data.SqlServer/CareerManagement.Data.SqlServer.csproj
```
