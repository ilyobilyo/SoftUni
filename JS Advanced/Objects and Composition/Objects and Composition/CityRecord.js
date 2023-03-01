function CityRecord(name, population, treasury){
    const city = {};

    //Variant 1
    city.name = name;
    city.population = population;
    city.treasury = treasury;
    //return city;

    //Variant 2
    return {name, population, treasury};
}

console.log(CityRecord('Tortuga',
7000,
15000
));