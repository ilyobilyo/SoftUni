function TownPopulation(input){
    const result = {};

    for(let data of input){
        let [name, pop] = data.split(' <-> ');
        let population = Number(pop);
        if(result[name] == undefined){
            result[name] = population;
        }else{
            result[name] += population;
        }
    }

    for(let town in result){
        console.log(`${town} : ${result[town]}`);
    }
}

TownPopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

)