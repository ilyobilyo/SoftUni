function slove(n, m){
    let firstNum = Number(n);
    let secondNum = Number(m);

    let sum = 0;

    for(let i = firstNum; i <= secondNum; i++){
        sum += i;
    }

    return sum;
}

console.log(slove('-8','20')); 
