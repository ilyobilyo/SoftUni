function solve(area, vol, input){
    let coordinates = JSON.parse(input);

    let output = [];
    
    for (const cube of coordinates) {

        let result = {
            area: area.call(cube),
            volume: vol.call(cube),
        };
        output.push(result);
    }

    return output;
}

console.log(solve(area,vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
    ));

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};