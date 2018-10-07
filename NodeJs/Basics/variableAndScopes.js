{
    //Block Scope
}

//let keyword limits the scope of the variable
//we use const keyword when the reference assigned needs to be constant
//reference is to the object but the value can be changed

//Scalar values - we can think of it as immutable, we can't change the reference either
const a = 42;
const greeting = 'Hello';


//Array and objects, here const will guarantee that the variable is pointing to the same array or object
//but the content of the array can still be mutated
const numbers = [2, 4, 6];
const person = {
    firstName : 'John',
    lastName : 'Doe'
};

//to immutate object value, there exists a freeze method which freezes first level object only