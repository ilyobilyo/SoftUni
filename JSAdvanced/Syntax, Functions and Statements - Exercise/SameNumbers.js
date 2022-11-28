function slove(input) {
    let string = `${input}`;
    let sum = 0;
    let isValid = true;

    for (let i = 0; i < string.length - 1; i++) {
        sum += Number(string[i]);
        if (string[i] !== string[i + 1] && isValid) {
            isValid = false;
        }

        if (i === string.length - 2) {
            sum += Number(string[i + 1]);
        }
    }

    console.log(isValid);
    console.log(sum);
}

slove(123);