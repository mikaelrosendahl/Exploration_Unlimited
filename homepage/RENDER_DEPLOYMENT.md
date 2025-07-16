# GitHub Actions + Render Deployment Guide - Staging Environment

## 🚀 Staging miljö setup med GitHub Actions och Render

### Konfiguration som gjorts:

1. **Package.json** - Uppdaterat default build script till staging
2. **Server.js** - Uppdaterat för att hantera olika miljöer via NODE_ENV
3. **Angular.json** - Optimerat staging build-konfiguration  
4. **Environment.st.ts** - Förbättrat med staging-specifika inställningar
5. **build.yml** - Uppdaterat för att bygga med staging-konfiguration
6. **deploy-st.yml** - Redan konfigurerad med Render deploy hooks

### Deployment Process:

#### Automatisk deployment via GitHub Actions:
1. **Push till master branch** → Triggar automatiskt:
   - `build.yml` - Bygger både backend (.NET) och frontend (Angular) för staging
   - `deploy-st.yml` - Deployer till Render via webhook

#### Manuell deployment:
1. Gå till GitHub repo → Actions tab
2. Välj "Deploy to Staging" workflow
3. Klicka "Run workflow" → "Run workflow"

### Render Service Konfiguration:

Dina Render services bör vara konfigurerade med:

**Staging Client Service:**
- **Build Command**: `npm run build`
- **Start Command**: `NODE_ENV=staging npm start`
- **Environment Variables**: `NODE_ENV=staging`
- **Auto-Deploy**: Disabled (använder GitHub Actions hooks istället)

**Staging API Service:**
- Redan konfigurerad med deploy hook

### Workflow Files:

#### `.github/workflows/build.yml`
- Bygger både frontend och backend
- Kör tester
- Triggas på push till master

#### `.github/workflows/deploy-st.yml`
- Deployer till staging miljö
- Använder Render deploy hooks
- Triggas manuellt eller på push till master

### Lokalt test av staging build:

```bash
cd homepage

# Bygg för staging
npm run build:staging

# Testa lokalt
NODE_ENV=staging npm start
```

### Troubleshooting:

#### Om deployment misslyckas:
1. Kolla GitHub Actions logs under "Actions" tab
2. Verifiera att Render deploy hooks är aktiva
3. Kontrollera Render service logs

#### Om bygget misslyckas:
- Kontrollera att alla dependencies finns i package.json
- Verifiera att Angular CLI version är kompatibel
- Kolla build-logs i GitHub Actions

### URLs:
- **Staging API**: `https://explorationapi-st.onrender.com/api`
- **Staging Client**: Din Render staging client URL

### Nästa Deploy:
Bara pusha dina ändringar till master branch så kommer GitHub Actions automatiskt bygga och deploya till staging! 🚀
