#!/usr/bin/env node

/**
 * Smart build script som väljer Angular-konfiguration baserat på miljövariabel
 */

const { execSync } = require('child_process');

// Bestäm konfiguration baserat på NODE_ENV
const environment = process.env.NODE_ENV || 'staging';

let buildConfig;
switch (environment) {
  case 'production':
    buildConfig = 'production';
    break;
  case 'staging':
    buildConfig = 'staging';
    break;
  case 'development':
    buildConfig = 'development';
    break;
  default:
    buildConfig = 'staging'; // Default fallback
}

const buildCommand = `ng build --configuration ${buildConfig}`;

console.log(`🔧 Building with NODE_ENV=${environment}`);
console.log(`📦 Using Angular configuration: ${buildConfig}`);
console.log(`⚡ Running: ${buildCommand}`);

try {
  execSync(buildCommand, { stdio: 'inherit' });
  console.log(`✅ Build completed successfully for ${environment} environment!`);
} catch (error) {
  console.error(`❌ Build failed for ${environment} environment:`, error.message);
  process.exit(1);
}
