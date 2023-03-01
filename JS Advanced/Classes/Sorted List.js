class List {
    #elements = [];
    constructor() {
        this.size = this.#elements.length;
    }

    add(element) {
        this.#elements.push(element);
        this.size++;
        this.#elements.sort((a, b) => a - b);
    }

    remove(index) {
        if (index >= 0 && index < this.#elements.length) {
            this.#elements.splice(index, 1);
            this.size--;
            this.#elements.sort((a, b) => a - b);
        }
    }

    get(index) {
        if (index >= 0 && index < this.#elements.length) {
            return this.#elements[index];
        }
    }
}

var myList = new List();

myList.add(5);

myList.add(3);

myList.remove(0);
console.log(myList.get(0))
console.log(myList.size)





let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size);
list.remove(1);
console.log(list.size);