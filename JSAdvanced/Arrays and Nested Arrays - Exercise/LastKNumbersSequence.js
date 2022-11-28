function lastK(n, k){
    let arr = [1];
    for(let i = arr.length; i < n; i++){
        let sum = 0;
        if(arr.length <= k){
            for(let j = 0; j < arr.length; j++){
                sum += arr[j];
            }

            arr.push(sum);
        }else{
            for(let j = arr.length - 1; j >= arr.length - k; j--){
                sum += arr[j];
            }

            arr.push(sum)
        }
    }

    return arr;
}

console.log(lastK(6, 3));
console.log(lastK(8, 2));
