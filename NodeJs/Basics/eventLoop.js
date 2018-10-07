//when we do something as simple as
//node has started an Operating System process, node has finished the process and the OS terminated that process, it won't keep running without a reason
//console.log('Hey!');

setInterval(() => console.log('Hello'), 2000);

//here, however, the OS process remains busy. This is due to event loop
//event loop is what node uses to process asynchronous actions and interface them for you so that you don't have to deal with threads