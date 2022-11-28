function slove(x1, y1, x2, y2){
    let checkFirstPointValueToZero = Math.sqrt(((x1 - 0) * (x1 - 0)) + ((y1 - 0) * (y1 - 0)));
    let checkSecondPointValueToZero = Math.sqrt(((x2 - 0) * (x2 - 0)) + ((y2 - 0) * (y2 - 0)));
    let checkFirstPointValueToSecond = Math.sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

    if(Number.isInteger(checkFirstPointValueToZero)){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(checkSecondPointValueToZero)){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if(Number.isInteger(checkFirstPointValueToSecond)){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

slove(2, 1, 1, 1);
slove(3, 0, 0, 4);