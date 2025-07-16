# GitHub Actions + Render Deployment Guide - Staging Environment

## 🚀 Staging miljö setup med GitHub Actions och Render

### Konfiguration som gjorts:

1. **Package.json** - Uppdaterat default build script till staging
2. **Server.js** - Uppdaterat för att hantera olika miljöer via NODE_ENV
3. **Angular.json** - Optimerat staging build-konfiguration  
4. **Environment.st.ts** - Förbättrat med staging-specifika inställningar (`production: true`)
5. **Main.ts** - Lagt till enableProdMode() för production builds
6. **build.yml** - Uppdaterat för att bygga med staging-konfiguration
7. **deploy-st.yml** - Redan konfigurerad med Render deploy hooks

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
- **Viktigt**: Kontrollera CORS-inställningar för staging-domänen

### 🔧 Felsökning av vanliga problem:

#### 1. "Angular is running in development mode"
**Lösning**: Nu fixat - staging environment har `production: true`

#### 2. CORS-fel från API
**Problem**: `Access to XMLHttpRequest blocked by CORS policy`
**Lösning**: 
- Kontrollera att staging API:t tillåter staging client-domänen
- Lägg till `https://homepage-fnpo.onrender.com` (eller din faktiska staging URL) i API:ts CORS-konfiguration

#### 3. Appen pekar på fel API
**Kontroll**: Öppna browser developer tools och kolla console logs
- Du borde se: `API URL: https://explorationapi-st.onrender.com/api`
- Om du ser dev-URL istället, har bygget inte uppdaterats på Render

#### 4. Bygget använder fel environment
**Lösning**: Force rebuild på Render:
1. Gå till Render dashboard
2. Välj din staging service  
3. Klicka "Manual Deploy" → "Deploy latest commit"

### Verification Steps:

1. **Kolla environment i browser console**: 
   ```
   === ENVIRONMENT CHECK ===
   Production mode: true
   API URL: https://explorationapi-st.onrender.com/api
   ```

2. **Testa API endpoint**: Öppna `https://explorationapi-st.onrender.com/api/diary` i browser

3. **Kontrollera CORS headers**: API borde returnera rätt CORS headers för staging-domänen

### Workflow Files:

#### `.github/workflows/build.yml`
- Bygger både frontend och backend
- Kör tester
- Triggas på push till master

#### `.github/workflows/deploy-st.yml`
- Deployer till staging miljö
- Använder Render deploy hooks
- Triggas manuellt eller på push till master

### URLs:
- **Staging API**: `https://explorationapi-st.onrender.com/api`
- **Staging Client**: Din Render staging client URL

### Nästa Deploy:
Bara pusha dina ändringar till master branch så kommer GitHub Actions automatiskt bygga och deploya till staging! 🚀

### Om problem kvarstår:
1. **Force rebuild** på Render
2. **Kontrollera API CORS-inställningar** 
3. **Verifiera environment logs** i browser console
