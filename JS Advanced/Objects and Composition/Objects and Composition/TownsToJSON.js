function TownsToJSON(input) {
    let pattern = RegExp("[\| ][ \| ][ \|]*")
    let columNames = input[0].split(pattern).filter(x => x);
    let result = [];

    for (let i = 1; i < input.length; i++) {
        let townObj = {};
        let townData = input[i].split(pattern).filter(x => x);
        let latitude = Number(townData[1]).toFixed(2);
        let longitude = Number(townData[2]).toFixed(2);
        townObj[columNames[0]] = townData[0];
        townObj[columNames[1]] = Number(latitude);
        townObj[columNames[2]] = Number(longitude);
        result.push(townObj);
    }

    let output = JSON.stringify(result);
    console.log(output);
}

TownsToJSON(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']

);