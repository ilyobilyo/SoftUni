function solution(num){
    let number = num;

    return function add(numToAdd){
        return number + numToAdd
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
