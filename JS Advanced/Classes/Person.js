function solve() {
    class Person {
        _firstName
        _lastName
        _age
        _email
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }

        get firstName() {
            return this._firstName;
        }
        set firstName(value){
            if (value == undefined){
                this._firstName = '';
            }

            this._firstName = value;
        }

        get lastName() {
            return this._lastName;
        }
        set lastName(value){
            if (value == undefined){
                this._lastName = '';
            }

            this._lastName = value;
        }

        get age() {
            return this._age;
        }
        set age(value){
            if (value == undefined){
                this._age = '';
            }

            this._age = value;
        }

        get email() {
            return this._email;
        }
        set email(value){
            if (value == undefined){
                this._email = '';
            }

            this._email = value;
        }

        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    }

    let result = [];

    let person1 = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    let person2 = new Person('SoftUni');
    let person3 = new Person('Stephan', 'Johnson', 25);
    let person4 = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');

    result.push(person1);
    result.push(person2);
    result.push(person3);
    result.push(person4);

    return result;
}

solve();