function slove(firstText, secondText, thirdText){
    let sum = firstText.length + secondText.length + thirdText.length;

    let average = Math.floor(sum / 3);

    console.log(sum);
    console.log(average);
}

slove('chocolate', 'ice cream', 'cake');
slove('pasta', '5', '22.3');