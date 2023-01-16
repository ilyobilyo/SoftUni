function attachEventsListeners() {
    const btns = document.querySelectorAll('input[type="button"]');

    const inputDays = document.querySelector('input[id="days"]');
    const inputHrs = document.querySelector('input[id="hours"]');
    const inputMins = document.querySelector('input[id="minutes"]');
    const inputSeconds = document.querySelector('input[id="seconds"]');

    for (const btn of btns) {
        btn.addEventListener('click', convert);
    }

    let units = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    function convert(e){
        let inputValue = e.target.parentElement.querySelector('input[type="text"]').value;
        let unitType = e.target.parentElement.querySelector('input').id;

        let days = Number(inputValue) / units[unitType];

        let result = {
            days: days,
            hours: days * units.hours,
            minutes: days * units.minutes,
            seconds: days * units.seconds
        }

        inputDays.value = result.days;
        inputHrs.value = result.hours;
        inputMins.value = result.minutes;
        inputSeconds.value = result.seconds;
    }
}