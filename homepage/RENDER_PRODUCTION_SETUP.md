# Render Production Setup Instructions

## 🚀 Production Environment Configuration för Render

### Problem identifierat:
Render försöker köra `npm run build --configuration production` vilket är felaktigt Angular CLI syntax.

### Korrekt Render-konfiguration:

#### **Production Service på Render:**

**Build Command:**
```
npm install && npm run build:prod
```

**Start Command:**
```
NODE_ENV=production npm start
```

**Environment Variables:**
- `NODE_ENV=production`
- `PORT=10000` (optional, Render sätter detta automatiskt)

### Build Commands förklaring:

- ✅ **Korrekt**: `npm run build:prod` (använder vårt script från package.json)
- ❌ **Felaktigt**: `npm run build --configuration production` (Angular CLI syntax, inte npm script)

### Alternativa build commands som fungerar:

1. **Rekommenderad**: `npm install && npm run build:prod`
2. **Alternativ**: `npm ci && npm run build:prod` (snabbare i production)
3. **Med explicit config**: `npm install && npx ng build --configuration production`

### Steg för att uppdatera Render Production Service:

1. **Gå till Render Dashboard**
2. **Välj din Production Service**
3. **Gå till Settings**
4. **Uppdatera "Build Command" till**: `npm install && npm run build:prod`
5. **Uppdatera "Start Command" till**: `NODE_ENV=production npm start`
6. **Sätt Environment Variable**: `NODE_ENV=production`
7. **Klicka "Save Changes"**
8. **Klicka "Manual Deploy" → "Deploy latest commit"**

### Verification:

Efter deployment borde du se i browser console:
```
=== ENVIRONMENT CHECK ===
Production mode: true
API URL: https://explorationapi.onrender.com/api
```

### Troubleshooting:

Om bygget fortfarande misslyckas:
1. Kontrollera att Node.js version är kompatibel (>=16)
2. Försök med `npm ci` istället för `npm install`
3. Kontrollera att alla dependencies finns i package.json

### Production vs Staging Differences:

| Environment | Build Command | API URL | Node Environment |
|-------------|---------------|---------|------------------|
| **Staging** | `npm run build` (default=staging) | `explorationapi-st.onrender.com` | `NODE_ENV=staging` |
| **Production** | `npm run build:prod` | `explorationapi.onrender.com` | `NODE_ENV=production` |
