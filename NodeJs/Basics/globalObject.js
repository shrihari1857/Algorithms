//you should avoid creating global variable
// this global object is equivalent to window object on browser
//So, when we do node > setTimeOut we're actually using global.setTimeOut
console.dir(global, { depth: 0});