function slove(matrix){
    let mainSum = 0;
    let secondSum = 0;

    for(let row = 0; row < matrix.length; row++){
        for(let col = row; col < matrix[row].length; col++){
            mainSum += matrix[row][col];
            break;
        }
    }

    for(let row = 0; row < matrix.length; row++){
        for(let col = matrix[row].length - 1 - row; col >= 0; col--){
            secondSum += matrix[row][col];
            break;
        }
    }

    console.log(mainSum, secondSum);
}

slove([[3, 5, 17],
       [-1, 7, 14],
       [1, -8, 89]]
   );