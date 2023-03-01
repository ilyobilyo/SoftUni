function slove(input) {
    let print = [];

    for(let i = 0; i < input.length; i++){
        if(i % 2 == 0){
            print.push(input[i]);
        }
    }

    console.log(print.join(" "));
}

slove(['20', '30', '40', '50', '60']);