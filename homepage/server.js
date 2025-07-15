const express = require('express');
const path = require('path');
const app = express();

const appName = 'homepage-dev'; // exakt namn på mappen i dist/
const distFolder = path.join(__dirname, `dist/${appName}`);
const port = process.env.PORT || 10000;

app.use(express.static(distFolder));

app.get('*', (req, res) => {
  res.sendFile(path.join(distFolder, 'index.html'));
});

app.listen(port, '0.0.0.0', () => {
  console.log(`Listening on port ${port}`);
});
