function sumTable() {
    const prices = document.querySelectorAll('td');
    let sum = 0;
    for(let i = 1; i < prices.length - 1; i+=2){
        sum += Number(prices[i].textContent);
    }

    document.querySelector('#sum').textContent = sum;
}