const mystery = "answer";
const PI = Math.PI;
const obj = {
    p1: 10,
    p2: 20,
    f1() {},    //property that holds function
    f2: () => {},
    [mystery]: 42,   //javascript will evaluate mystery and assign it 42, dynamic property
    PI  //shorter syntax, will result in PI:Math.PI value
}

console.log(obj);


/*
{ p1: 10,
  p2: 20,
  f1: [Function: f1],
  f2: [Function: f2],
  answer: 42,
  PI: 3.141592653589793 }
*/