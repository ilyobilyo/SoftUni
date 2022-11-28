function slove(numberAsString, 
    operation1, 
    operation2, 
    operation3, 
    operation4, 
    operation5){
        let number = Number(numberAsString);
        let operations = [operation1, operation2, operation3, operation4, operation5];

        for(let operation of operations){
            switch(operation){
                case'chop':{
                    number /= 2;
                    break;
                }
                case'dice':{
                    number = Math.sqrt(number);
                    break;
                }
                case'spice':{
                    number++;
                    break;
                }
                case'bake':{
                    number *= 3;
                    break;
                }
                case'fillet':{
                    number = number - (number * 0.20);
                    break;
                }
            }

            console.log(number);
        }
}

slove('9', 'dice', 'spice', 'chop', 'bake', 'fillet');