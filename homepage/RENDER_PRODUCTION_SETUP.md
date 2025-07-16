# Render Production Setup Instructions

## 🚀 Production Environment Configuration för Render

### Problem löst:
✅ Smart build-script som automatiskt väljer rätt Angular-konfiguration baserat på NODE_ENV
✅ Fungerar med både Render's befintliga build command och våra egna scripts

### Korrekt Render-konfiguration:

#### **Production Service på Render:**

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
NODE_ENV=production npm start
```

**Environment Variables:**
- `NODE_ENV=production`

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
- Läser `NODE_ENV` miljövariabel
- Väljer automatiskt rätt Angular-konfiguration:
  - `NODE_ENV=production` → `ng build --configuration production`
  - `NODE_ENV=staging` → `ng build --configuration staging`
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
   - Start Command: `NODE_ENV=production npm start`
   - Environment Variables: `NODE_ENV=production`
3. **För Staging Service**:
   - Build Command: `npm install && npm run build`
   - Start Command: `NODE_ENV=staging npm start`  
   - Environment Variables: `NODE_ENV=staging`
4. **Deploy båda services**

### Varför denna lösning är bättre:

- ✅ **Flexibel**: Fungerar med både gamla och nya build commands
- ✅ **Tydlig**: Visar exakt vilken konfiguration som används
- ✅ **Robust**: Fallback till staging om NODE_ENV inte är satt
- ✅ **Debug-vänlig**: Loggar alla steg i build-processen
