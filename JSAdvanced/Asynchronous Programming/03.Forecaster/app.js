function attachEvents() {
    document.querySelector('#submit').addEventListener('click', getWeather);
    const input = document.querySelector('#location');
    const locationsUrl = "http://localhost:3030/jsonstore/forecaster/locations";
    const todayUrl = "http://localhost:3030/jsonstore/forecaster/today/";
    const upcomingUrl = "http://localhost:3030/jsonstore/forecaster/upcoming/";
    const divCurrent = document.querySelector('#current');
    const divUpcoming = document.querySelector('#upcoming');

    const divForecasts = document.createElement('div');
    divForecasts.classList.add('forecasts');

    const divUpcomingData = document.createElement('div');
    divUpcomingData.classList.add('forecast-info');

    const enumIcons = {
        Sunny: '&#x2600',
        Overcast: '&#x2601',
        Rain: '&#x2614',
        Degrees: '&#176'
    }

    enumIcons["Partly sunny"] = '&#x26C5';

    async function getWeather() {
        try {
            divForecasts.innerHTML = "";
            divUpcomingData.innerHTML = "";

            document.querySelector("#forecast").style.display = 'block';
            const locationResponse = await fetch(locationsUrl);
            const allLocations = await locationResponse.json();

            const locationInputValue = input.value;

            const location = allLocations.find(x => x.name == locationInputValue);

            const [todayData, upcomingData] = await Promise.all([
                GetToday(location),
                GetUpcoming(location)
            ]);

            CreateToday(todayData);

            upcomingData.forecast.forEach(x => {
                CreateUpcomeing(x);
            });

        } catch (error) {
            divForecasts.textContent = "Error";
        }


        function CreateUpcomeing(upcomingData) {
            const condition = upcomingData.condition;
            const high = upcomingData.high;
            const low = upcomingData.low;

            const spanContainer = document.createElement('span');
            spanContainer.classList.add('upcoming');

            const spanSymbol = document.createElement('span');
            spanSymbol.classList.add('symbol');
            spanSymbol.innerHTML = enumIcons[condition];

            const spanTemperature = document.createElement('span');
            spanTemperature.classList.add('forecast-data');
            spanTemperature.innerHTML = `${low}${enumIcons.Degrees}/${high}${enumIcons.Degrees}`;

            const spanCondition = document.createElement('span');
            spanCondition.classList.add('forecast-data');
            spanCondition.textContent = condition;

            spanContainer.appendChild(spanSymbol);
            spanContainer.appendChild(spanTemperature);
            spanContainer.appendChild(spanCondition);

            divUpcomingData.appendChild(spanContainer);
            divUpcoming.appendChild(divUpcomingData);
        }
    }



    function CreateToday(dataToday) {
        const condition = dataToday.forecast.condition;
        const high = dataToday.forecast.high;
        const low = dataToday.forecast.low;

        const spanSymbol = document.createElement('span');
        spanSymbol.classList.add('condition');
        spanSymbol.classList.add('symbol');
        spanSymbol.innerHTML = enumIcons[condition];

        const spanContainer = document.createElement('span');
        spanContainer.classList.add('condition');

        const spanLocationName = document.createElement('span');
        spanLocationName.classList.add('forecast-data');
        spanLocationName.textContent = dataToday.name;

        const spanTemperature = document.createElement('span');
        spanTemperature.classList.add('forecast-data');
        spanTemperature.innerHTML = `${low}${enumIcons.Degrees}/${high}${enumIcons.Degrees}`;

        const spanCondition = document.createElement('span');
        spanCondition.classList.add('forecast-data');
        spanCondition.textContent = condition;

        spanContainer.appendChild(spanLocationName);
        spanContainer.appendChild(spanTemperature);
        spanContainer.appendChild(spanCondition);

        divForecasts.appendChild(spanSymbol);
        divForecasts.appendChild(spanContainer);

        divCurrent.appendChild(divForecasts);
    }

    async function GetToday(location) {
        const todayResponse = await fetch(todayUrl + location.code);
        const todayData = await todayResponse.json();

        return todayData;
    }

    async function GetUpcoming(location) {
        const upcomingResponse = await fetch(upcomingUrl + location.code);
        const upcomingData = await upcomingResponse.json();

        return upcomingData;
    }
}

attachEvents();