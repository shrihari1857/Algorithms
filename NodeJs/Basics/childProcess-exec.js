const { exec } = require('child_process');

const child = exec('uptime', (err, stdout, stderr) => {
    if(err){
        console.log('Error: ' + stderr);
    } else{
        console.log('Output: ' + stderr);
    }
});

console.log("PID is: " + child.pid);