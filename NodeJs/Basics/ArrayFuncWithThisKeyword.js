this.id = 'exports';

const testerObject = {
        func1 : function(){
            console.log('func1', this);

    },
        func2 : () => {
        console.log('func2', this);

    }
}

testerObject.func1();
testerObject.func2();

/*
Output
func1 { func1: [Function: func1], func2: [Function: func2] }    //here, 'this' is the tester object
func2 { id: 'exports' } //here, this is just the tester object
*/

const sqaure = a => a * a;

[1, 2, 3, 4].map(a => a * a);