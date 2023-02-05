class Stringer{
    #innerLength

    constructor(innerString, innerLength){
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    get innerLength(){
        return this.#innerLength;
    }
    set innerLength(value){
        if (value < 0) {
            value = 0;
        }

        this.#innerLength = value;
    }

    increase(length){
        this.innerLength += length;
    }

    decrease(length){
        this.innerLength -= length;

        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString(){
        let result = '';

        for (let i = 0; i < this.innerLength; i++) {
            if (i >= this.innerString.length) {
                break;
            }

            result += this.innerString[i];         
        }

        if (this.innerLength < this.innerString.length) {
            result += '...';
        }

        return result;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
