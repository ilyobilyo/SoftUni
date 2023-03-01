function ConstructionCrew(worker) {
    if(worker.dizziness){
        let hydrated = 0.1 * worker.weight * worker.experience;
        worker.levelOfHydrated += hydrated;
        worker.dizziness = false;
    }

    return worker;
}

console.log(ConstructionCrew(
    {
        weight: 120,
        experience: 20,
        levelOfHydrated: 200,
        dizziness: true
    }
));