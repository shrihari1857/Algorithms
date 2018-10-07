// const PI = Math.PI;
// const E = Math.E;
// const SQRT2 = Math.SQRT2;

//const {PI, E, SQRT2} = Math;

//console.log(PI);

const circle = {
    label: "label1",
    radius: 4
};

const circleArea = ({radius}, {precision = 2} = {}) => {    //here precision paramter is optional and it's default value is set to 2
    console.log((Math.PI * radius * radius).toFixed(precision));
};

circleArea(circle);