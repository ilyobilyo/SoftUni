function attachEventsListeners() {
    let units = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    };

    document.querySelector('input[type="button"]').addEventListener('click', convert);

    function convert(e){
        let value = Number(e.target.parentElement.querySelector('input[type="text"]').value);
        let unit = e.target.parentElement.querySelector('select').value;
        let unitToConvert = document.getElementById('outputUnits').value;

        let toMeter = value * units[unit]
        let result = toMeter / units[unitToConvert];

        document.getElementById('outputDistance').value = result;
    }
}