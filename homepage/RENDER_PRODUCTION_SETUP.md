# Render Production Setup Instructions

## 🚀 Production Environment Configuration för Render

### Problem löst:
✅ Smart build-script som automatiskt väljer rätt Angular-konfiguration baserat på NODE_ENV
✅ Fungerar med både Render's befintliga build command och våra egna scripts

### **VIKTIGT: Production Environment Variables**

⚠️ **PROBLEM IDENTIFIERAT: Production pekar på staging API!**

**Du måste sätta dessa Environment Variables på din Production Render Service:**

1. **ASPNETCORE_ENVIRONMENT=Production** (kritiskt för att välja rätt Angular config)
2. **NODE_ENV=production** (optional, extra säkerhet)
3. **PORT=10000** (optional, Render sätter detta automatiskt)

### 🚨 AKUT FIX - Sätt ASPNETCORE_ENVIRONMENT=Production:

1. **Gå till Render Dashboard** → https://dashboard.render.com
2. **Välj din Production Service** (`explorationunlimited.se`)
3. **Gå till "Environment" tab**
4. **Lägg till Environment Variable**:
   - Key: `ASPNETCORE_ENVIRONMENT`
   - Value: `Production`
5. **Klicka "Save Changes"**
6. **Deploy om manuellt** för att använda nya variables

### Varför detta är viktigt:
- Utan ASPNETCORE_ENVIRONMENT=Production använder build-scriptet staging-config
- Detta ger fel API URL: `explorationapi-st.onrender.com` istället för `explorationapi.onrender.com`
- CORS-fel uppstår eftersom staging API inte har production domain tillåten

### **Production Service på Render:**

**Build Command:** (Välj ett av dessa)
```
npm install && npm run build
```
ELLER den gamla varianten (fungerar nu också):
```
npm install; npm run build --configuration production
```

**Start Command:**
```
ASPNETCORE_ENVIRONMENT=Production npm start
```

**Environment Variables:**
- `ASPNETCORE_ENVIRONMENT=Production`

#### **Staging Service på Render:**

**Build Command:**
```
npm install && npm run build
```

**Start Command:**
```
NODE_ENV=staging npm start
```

**Environment Variables:**
- `NODE_ENV=staging`

### Hur det fungerar:

**Smart Build Script** (`build-script.js`):
- Läser `ASPNETCORE_ENVIRONMENT` och `NODE_ENV` miljövariablerna
- Väljer automatiskt rätt Angular-konfiguration:
  - `ASPNETCORE_ENVIRONMENT=Production` → `ng build --configuration production`
  - `ASPNETCORE_ENVIRONMENT=Staging` → `ng build --configuration staging`
  - `NODE_ENV=production` → `ng build --configuration production`
  - Default fallback → `ng build --configuration staging`

### Build Commands som nu fungerar:

1. ✅ `npm run build` (använder smart script + NODE_ENV)
2. ✅ `npm run build:prod` (direkt production build)
3. ✅ `npm run build:staging` (direkt staging build)
4. ✅ `npm run build --configuration production` (ignorerar extra argument, använder NODE_ENV)

### Verification efter deployment:

**Production** (`https://explorationunlimited.se`):
```
=== ENVIRONMENT CHECK ===
Production mode: true
API URL: https://explorationapi.onrender.com/api
Environment: {production: true, staging: false, ...}
```

**Staging** (`https://homepage-fnpo.onrender.com`):
```
=== ENVIRONMENT CHECK ===
Production mode: true
API URL: https://explorationapi-st.onrender.com/api  
Environment: {production: true, staging: true, ...}
```

### Steg för att uppdatera Render Services:

1. **Pusha de nya filerna** (build-script.js och uppdaterad package.json)
2. **För Production Service**:
   - Build Command: `npm install && npm run build`
   - Start Command: `ASPNETCORE_ENVIRONMENT=Production npm start`
   - Environment Variables: `ASPNETCORE_ENVIRONMENT=Production`
3. **För Staging Service**:
   - Build Command: `npm install && npm run build`
   - Start Command: `ASPNETCORE_ENVIRONMENT=Staging npm start`  
   - Environment Variables: `ASPNETCORE_ENVIRONMENT=Staging`
4. **Deploy båda services**

### Varför denna lösning är bättre:

- ✅ **Flexibel**: Fungerar med både gamla och nya build commands
- ✅ **Tydlig**: Visar exakt vilken konfiguration som används
- ✅ **Robust**: Fallback till staging om NODE_ENV inte är satt
- ✅ **Debug-vänlig**: Loggar alla steg i build-processen
