const[first, second,,fourth] = [10, 20, 30, 40]
console.log(first);
console.log(second);
console.log(fourth);
console.log('\n');
const[First, ...restOfItems] = [10, 20, 30, 40]

console.log(First);
console.log(restOfItems);


const data = {
    temp1: '001',
    temp2: '002',
    firstName: 'John',
    lastName: 'Doe'
};

const {temp1, temp2, ...person} = data;

console.log(temp1);
console.log(temp2);
console.log(person);
