function slove(input){
    if(typeof(input) === 'number'){
        let area = Math.PI * input * input;

        console.log(area.toFixed(2));
    }else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(input)}.`);
    }
}

slove(5);
slove('glos');