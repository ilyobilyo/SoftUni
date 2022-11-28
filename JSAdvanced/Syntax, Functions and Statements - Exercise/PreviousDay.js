function slove(year, month, day){
    let date = new Date(year, month - 1, day - 1);

    return `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
}

console.log(slove(2022, 2, 1));