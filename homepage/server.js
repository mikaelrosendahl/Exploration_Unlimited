const express = require('express');
const path = require('path');
const app = express();

// Bestäm vilken build-mapp som ska användas baserat på miljövariabel
const environment = process.env.NODE_ENV || 'development';
let appName = 'homepage'; // Alla miljöer använder samma output-mapp

const distFolder = path.join(__dirname, `dist/${appName}`);
const port = process.env.PORT || 10000;

console.log(`Starting server in ${environment} mode`);
console.log(`Serving files from: ${distFolder}`);

app.use(express.static(distFolder));

app.get('*', (req, res) => {
  res.sendFile(path.join(distFolder, 'index.html'));
});

app.listen(port, '0.0.0.0', () => {
  console.log(`Listening on port ${port} in ${environment} mode`);
});
