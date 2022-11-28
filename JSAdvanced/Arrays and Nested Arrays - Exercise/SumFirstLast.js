function SumFirstLast(input){
    let sum = Number(input.shift()) + Number(input.pop()); 

    return sum;
}

console.log(SumFirstLast(['20', '30', '40']));