import { environment } from '../environments/environment';

console.log('=== ENVIRONMENT CHECK ===');
console.log('Production mode:', environment.production);
console.log('API URL:', environment.apiUrl);
console.log('Environment:', environment);
console.log('=========================');
