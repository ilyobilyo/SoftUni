function slove(fruitType, weight, pricePerKilo){
    let price = weight * pricePerKilo;

    console.log(`I need $${(price/1000).toFixed(2)} to buy ${(weight/1000).toFixed(2)} kilograms ${fruitType}.`);
}

slove('orange', 2500, 1.80);