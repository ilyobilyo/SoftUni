function LowestPrice(input) {
    let result = [];
    for (let data of input) {
        let dataArr = data.split(" | ");
        let obj = {
            productName: dataArr[1],
            price: Number(dataArr[2]),
            town: dataArr[0],
        };
        if (result.some(x => x.productName === obj.productName && x.price > obj.price)) {
            let objToModify = result.find(x => x.productName === obj.productName);
            objToModify.price = obj.price;
            objToModify.town = obj.town;
        }

        if (!result.some(x => x.productName === obj.productName)) {
            result.push(obj);
        }
    }

    for(let prod of result){
        console.log(`${prod.productName} -> ${prod.price} (${prod.town})`);
    }
}

LowestPrice(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'Mexico City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Washington City | Mercedes | 1000']
);