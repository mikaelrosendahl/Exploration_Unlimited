#!/usr/bin/env node

/**
 * Smart build script som väljer Angular-konfiguration baserat på miljövariabel
 */

const { execSync } = require('child_process');

// Bestäm konfiguration baserat på flera faktorer
const nodeEnv = process.env.NODE_ENV || '';
const aspnetEnv = process.env.ASPNETCORE_ENVIRONMENT || '';
const renderServiceName = process.env.RENDER_SERVICE_NAME || '';

// Kombinera alla miljövariablerna för bästa detection
// Prioritera ASPNETCORE_ENVIRONMENT först eftersom det är vad du använder
const environment = aspnetEnv || nodeEnv || 'staging';
const isRenderProduction = renderServiceName.includes('prod') || renderServiceName.includes('production');

let buildConfig;

// Prioritera både NODE_ENV och ASPNETCORE_ENVIRONMENT
if (environment.toLowerCase() === 'production' || isRenderProduction) {
  buildConfig = 'production';
} else if (environment.toLowerCase() === 'staging') {
  buildConfig = 'staging';
} else if (environment.toLowerCase() === 'development') {
  buildConfig = 'development';
} else {
  // Smart fallback: om inget är satt, gissa baserat på service name
  if (renderServiceName.includes('prod') || renderServiceName.includes('production')) {
    buildConfig = 'production';
  } else {
    buildConfig = 'staging'; // Default fallback
  }
}

const buildCommand = `ng build --configuration ${buildConfig}`;

console.log(`🔧 Environment Detection:`);
console.log(`   NODE_ENV: ${nodeEnv}`);
console.log(`   ASPNETCORE_ENVIRONMENT: ${aspnetEnv}`);
console.log(`   RENDER_SERVICE_NAME: ${renderServiceName}`);
console.log(`   Combined environment: ${environment}`);
console.log(`   Detected production: ${isRenderProduction}`);
console.log(`📦 Selected Angular configuration: ${buildConfig}`);
console.log(`⚡ Running: ${buildCommand}`);

try {
  execSync(buildCommand, { stdio: 'inherit' });
  console.log(`✅ Build completed successfully for ${buildConfig} configuration!`);
} catch (error) {
  console.error(`❌ Build failed for ${environment} environment:`, error.message);
  process.exit(1);
}
