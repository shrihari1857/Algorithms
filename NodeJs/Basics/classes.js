class person {
    constructor(name){
        this.name = name;
    }

    greet() {
        console.log(`Hello from ${this.name}`);
    }
}

class student extends person {
    constructor(name, level){
        super(name);
        this.level = level;
    }
    greet(){
        console.log(`Hello from ${this.name} from ${this.level}`);
    }
}

const p1 = new person('John');
const p2 = new student('Mary', 'Level 2');
const p3 = new student('Jerry', 'Level 3');

p3.greet = () => console.log('I am special');

p1.greet();
p2.greet();
p3.greet();