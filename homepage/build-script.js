#!/usr/bin/env node

/**
 * Smart build script som väljer Angular-konfiguration baserat på miljövariabel
 */

const { execSync } = require('child_process');

// Bestäm konfiguration baserat på flera faktorer
const environment = process.env.NODE_ENV || 'staging';
const renderServiceName = process.env.RENDER_SERVICE_NAME || '';
const isRenderProduction = renderServiceName.includes('prod') || renderServiceName.includes('production');

let buildConfig;

// Prioritera NODE_ENV först, men fallback på service name detection
if (environment === 'production' || isRenderProduction) {
  buildConfig = 'production';
} else if (environment === 'staging') {
  buildConfig = 'staging';
} else if (environment === 'development') {
  buildConfig = 'development';
} else {
  // Smart fallback: om inget NODE_ENV är satt, gissa baserat på service name
  if (renderServiceName.includes('prod') || renderServiceName.includes('production')) {
    buildConfig = 'production';
  } else {
    buildConfig = 'staging'; // Default fallback
  }
}

const buildCommand = `ng build --configuration ${buildConfig}`;

console.log(`🔧 Environment Detection:`);
console.log(`   NODE_ENV: ${environment}`);
console.log(`   RENDER_SERVICE_NAME: ${renderServiceName}`);
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
