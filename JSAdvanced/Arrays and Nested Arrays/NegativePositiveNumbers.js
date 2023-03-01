function slove(input){
    let arr =[];

    for(let number of input){
        if(number < 0){
            arr.unshift(number);
        }else{
            arr.push(number);
        }
    }

    console.log(arr.join("\n"));
}

slove([7, -2, 8, 9]);