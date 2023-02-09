async function getInfo() {
    const idInput = document.querySelector("#stopId");
    const ulBuses = document.querySelector("#buses");
    const stopNameDiv = document.querySelector("#stopName");

    const id = idInput.value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${id}`;

    ulBuses.innerHTML = "";
    idInput.value = "";

    try {
        const response = await fetch(url);
        const data = await response.json();

        stopNameDiv.textContent = data.name;
        Object.entries(data.buses).forEach(([bus, time]) => {
            const li = document.createElement('li');
            li.textContent = `Bus ${bus} arrives in ${time} minutes`;
            ulBuses.appendChild(li);
        });

    } catch (error) {
        stopNameDiv.textContent = "Error";
    }
}