const func = i => {
    console.log('Hello after ' + i + ' secs');
};

setTimeout(func, 4*1000, 4);
setTimeout(func, 8*1000, 8);

