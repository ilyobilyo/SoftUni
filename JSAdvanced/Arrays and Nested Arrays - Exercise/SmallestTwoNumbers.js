function slove(input){
    let arr = [];

    if(input.length > 1){
        for(let n = 0; n < 2; n++){
            let min = Number.MAX_VALUE;
    
            for(let i = 0; i < input.length; i++){
                if(input[i] < min){
                    min = input[i];
                }
            }
    
            let index = input.indexOf(min);
            input.splice(index, 1);
            
            arr.push(min);
        }
    }else{
        arr.push(input[0]);
    }
    
    console.log(arr.join(' '));
}

slove([30]);