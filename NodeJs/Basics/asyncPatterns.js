//async patterns
/*

call back functions are usually of the type function (err, data), the first parameter is the error object and then data, and hence these are called error first call back patter
However, if such call back functions are nested, the event loops becomes a bit complex. This is usually called pyramid of doom
To mitigate this problem, JS can now Promisify any async operation

 */

 const fs  = require('fs');
 const util = require('util');

 const readFile = util.promisify(fs.readFile);

 async function main() {
     const data = await readFile(__filename);
     console.log('File data is ', data);
 }

 main();
 console.log('Test');