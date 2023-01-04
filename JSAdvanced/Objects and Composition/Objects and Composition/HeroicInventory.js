function HeroInventory(input){
    let heros = [];

    for(let currHero of input){
        let heroData = currHero.split(" / ");
        let heroItems = [];
        if(heroData.length > 2){
            heroItems = heroData[2].split(", ");
        }
        let hero = {
            name: heroData[0],
            level: Number(heroData[1]),
            items: heroItems,
        };

        heros.push(hero);
    }

    let result = JSON.stringify(heros);

    return result;
}

console.log(HeroInventory(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 /']
));