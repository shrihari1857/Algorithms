const flatten = (arr, result = [])  => {
   for(let i = 0; i < arr.length; i++){
       let x = arr[i];
       if(Array.isArray(x)){
           flatten(x, result);
       } else {
           result.push(x);
       }
   }
   return result;

};

const flatten2 = (arr, v) => {
    var n = arr.slice();
    flatten(n[0]);
}

//console.log(flatten([1, [2], [3, [[4]]]]))
console.log([1, [2], [3, [[4]]]], true);