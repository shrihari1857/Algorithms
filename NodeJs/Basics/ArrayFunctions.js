 var a = 6;
const square = (a) => {
    return a * a;
}

console.log(square(a));

const X = function(){
    //"this" here is the called of X
}

const Y = () => {
    //"this" here is NOT the caller of Y
}