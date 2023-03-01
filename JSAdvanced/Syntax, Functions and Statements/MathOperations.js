function slove(firstNum, secondNum, operator) {
    let result;

    if (operator === '+') {
        result = firstNum + secondNum;
    } else if (operator === '-') {
        result = firstNum - secondNum;
    } else if (operator === '*') {
        result = firstNum * secondNum;
    } else if (operator === '/') {
        result = firstNum / secondNum;
    } else if (operator === '%') {
        result = firstNum % secondNum;
    } else if (operator === '**') {
        result = firstNum ** secondNum;
    }

    console.log(result);
}

slove(5, 2, '**');