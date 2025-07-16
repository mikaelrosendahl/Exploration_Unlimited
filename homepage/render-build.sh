#!/bin/bash

# Render build script för staging miljö
echo "Starting Render build for staging environment..."

# Installera dependencies
echo "Installing dependencies..."
npm ci

# Bygg för staging
echo "Building Angular app for staging..."
npm run build:staging

# Verifiera att build-mappen skapades
if [ -d "dist/homepage" ]; then
    echo "✅ Build successful! Files available in dist/homepage"
    ls -la dist/homepage
else
    echo "❌ Build failed! dist/homepage directory not found"
    exit 1
fi

echo "🚀 Ready to deploy!"
