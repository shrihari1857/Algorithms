/*
 A Module is a file or folder that contains code. The reason a file is called a module is because node first wraps a file around a function
 function (exports, module, require, __filename, __dirname)
 you can use export and module to define your API
 you can use require to require other modules
 __filename has path of the file
 __dirname has path to the folder hosting this file
 these are not global objects, they are just argument for wrapping function
 if we define a variable say, let g = 1 in this function. In node, this variable is local. However, in a browser this variable is global
 this functions returns module.exports property - node uses to manage the dependencies and to manage the API

 var greet = function () {
   console.log('Hello World');
};

module.exports = greet;

the above code is wrapped as IIFE(Immediately Invoked Function Expression) inside nodejs source code as follows:

(function (exports, require, module, __filename, __dirname) { //add by node

      var greet = function () {
         console.log('Hello World');
      };

      module.exports = greet;

}).apply();                                                  //add by node

return module.exports; 

and the above function is invoked (.apply()) and returned module.exports. At this time module.exports and exports pointing to the same reference.
Now, imagine you re-write 
exports = function () {
   console.log('Hello World');
};
console.log(exports);
console.log(module.exports);

the output will be

[Function]
{}
the reason is : module.exports is an empty object. We did not set anything to module.exports rather we set exports = function()..... in new greet.js. So, module.exports is empty.

Technically exports and module.exports should point to same reference(thats correct!!). But we use "=" when assigning function().... to exports, which creates another object in the memory. So, module.exports and exports produce different results. When it comes to exports we can't override it.

Now, imagine you re-write (this is called Mutation) greet.js (referring to Renee answer) as

exports.a = function() {
    console.log("Hello");
}

console.log(exports);
console.log(module.exports);
the output will be

{ a: [Function] }
{ a: [Function] }
As you can see module.exports and exports are pointing to same reference which is a function. If you set a property on exports then it will be set on module.exports because in JS, objects are pass by reference.

Conclusion is always use module.exports to avoid confusion

 */

 console.log(arguments);