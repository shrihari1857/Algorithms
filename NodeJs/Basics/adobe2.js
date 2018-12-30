const fl = (arr, mutable) => {
    var nodes = (mutable && arr) || arr.slice();
    var flattened = nodes.flat(1);
/*
    for(var node = nodes.shift(); node !== undefined; node = nodes.shift()){
        if(Array.isArray(node)){
            nodes.unshift.apply(nodes, node);
        } else {
            flattened.push(node);
        }
    }
    */
    return flattened;
}

console.log(fl([1, [2], [3, [[4]]]], true));