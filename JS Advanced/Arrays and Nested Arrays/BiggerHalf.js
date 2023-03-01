function slove(input){
    input.sort((a, b) => a - b);
    let arr =[];


    for(let i = Math.floor(input.length / 2); i < input.length; i++){
        arr.push(input[i]);
    }

    return arr;
}

console.log(slove([3, 19, 14, 7, 2, 19, 6]));