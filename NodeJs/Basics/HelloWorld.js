const http = require('http');

const server = http.createServer((req, res) =>{
    //console.log(req);
    //to avoid nested object, user dir
    console.dir(req, { depth:0 });
    res.end('Hello Node\n');
});

server.listen(4242, () => {
    console.log('Server is running..');
});