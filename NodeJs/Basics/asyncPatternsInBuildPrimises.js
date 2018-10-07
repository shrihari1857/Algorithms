const { readfile } = require('fs').promises;

async function main() {
    const data = await readfile(__filename);
    console.log(data);
}

main();
console.log('Test');