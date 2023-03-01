function StoreCatalouge(input) {
    let sortCtalouge = input.sort((a,b) => a.localeCompare(b));
    let firstLetter = undefined;
    let result = [];
    for(let product of sortCtalouge){
        if(product[0] !== firstLetter){
            firstLetter = product[0];
            result.push(firstLetter);
        }
        let productData = product.split(" : ");
        result.push(`  ${productData[0]}: ${productData[1]}`);
    }

    for(let catalugeItem of result){
        console.log(catalugeItem);
    }
}

StoreCatalouge(['Banana : 2',
'Rubics Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']

)