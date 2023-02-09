function solve() {
    const url = "http://localhost:3030/jsonstore/bus/schedule/";
    const departBtn = document.querySelector('#depart');
    const arriveBtn = document.querySelector('#arrive');
    const spanInfo = document.querySelector('span');
    let nextStopId = 'depot';

    async function depart() {
        try {
            const response = await fetch(url + nextStopId);
            const data = await response.json();

            spanInfo.textContent = `Next stop ${data.name}`;

            departBtn.disabled = 'true';
            arriveBtn.disabled = '';

        } catch (error) {
            spanInfo.textContent = "Error";
            departBtn.disabled = 'true';
            arriveBtn.disabled = 'true';
        }

    }

    async function arrive() {
        try {
            const response = await fetch(url + nextStopId);
            const data = await response.json();

            spanInfo.textContent = `Arriving at ${data.name}`;

            departBtn.disabled = '';
            arriveBtn.disabled = 'true';

            nextStopId = data.next;

        } catch (error) {
            spanInfo.textContent = "Error";
            departBtn.disabled = 'true';
            arriveBtn.disabled = 'true';
        }

    }

    return {
        depart,
        arrive
    };
}

let result = solve();