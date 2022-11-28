function slove(number) {

    if (number <= 0 || number === '') {
        number = 5;
    }

    for (let i = 0; i < number; i++) {
        let result = '';
        for (let j = 0; j < number; j++) {
            result += '* ';
        }
        
        console.log(result);
    }

}

slove(3);