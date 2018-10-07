//new way of using promises using async/await which makes code more readable especially when you are dealing with loops and other complexities

const https = require('https');

const fetch = url => {
    return new Promise((resolve, reject) => {
        https.get(url, (res) => {
            let data = '';
            res.on('data', (rd) => data = data + rd);
            res.on('end', () => resolve(data));
            res.on('error', reject);
        })
    });
}

(async () => {
    const data = await fetch('https://www.javascript.com/');
    console.log(data.length);
})();