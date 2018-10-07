//streams in node are event emitters. Process.stdout and in are both streams
const EvenEmitter = require('events');

const myEmitter = new EvenEmitter();

//important method of this object, just emits any string based on an event
myEmitter.emit('TEST_EVENT');

//other method, is how you can subscribe to events emitted by this object
//this is raised if the event is fired and the call back function is executed
//NOTE - this is a subscribe method and needs to be executed before the event emits
//However, if you do want the subscribe method to be executed later, you can use

setImmediate(() => {
    myEmitter.emit('TEST_EVENT'); //this line gets executed at the end, and hence all get fired
});

myEmitter.on('TEST_EVENT', () => {
    console.log('TEST_EVENT was fired');
});
