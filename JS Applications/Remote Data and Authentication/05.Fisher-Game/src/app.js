window.addEventListener('load', RenderPage);
document.querySelector('#logout').addEventListener('click', Logout);
const token = sessionStorage.getItem("accessToken");
const addBtn = document.querySelector('.add');
const loadBtn = document.querySelector('.load');
loadBtn.addEventListener('click', GetAllCatches);

function RenderPage() {
    document.querySelector('#catches').innerHTML = "";

    if (token) {
        document.querySelector('#guest').style.display = 'none';
        document.querySelector('.email').children[0].textContent = sessionStorage.getItem("email");
        document.querySelector('#user').style.display = 'inline-block';

        document.querySelector('#addForm').addEventListener('submit', AddCatch);
        addBtn.disabled = false;
    } else {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'inline-block';
        addBtn.disabled = true;
    }
}

async function AddCatch(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const catchData = Object.fromEntries(formData);

    if (catchData.angler === '' || catchData.angler === undefined ||
        catchData.bait === '' || catchData.bait === undefined ||
        catchData.captureTime === '' || catchData.captureTime === undefined ||
        catchData.location === '' || catchData.location === undefined ||
        catchData.species === '' || catchData.species === undefined ||
        catchData.weight === '' || catchData.weight === undefined) {
        return;
    }

    await Create(catchData.angler,
        catchData.weight,
        catchData.species,
        catchData.location,
        catchData.bait,
        catchData.captureTime);

}

function LoadCatches(allCatches) {
    document.querySelector('#catches').innerHTML = "";

    allCatches.forEach(x => {
        CreateCatchCard(x);

        if (sessionStorage.getItem('id') !== x._ownerId) {
            document.querySelector(`input[value="${x._ownerId}"]`)
                .parentElement
                .querySelector('.update')
                .disabled = true;

            document.querySelector(`input[value="${x._ownerId}"]`)
                .parentElement
                .querySelector('.delete')
                .disabled = true;

            const inputs = document.querySelector(`input[value="${x._ownerId}"]`)
                .parentElement
                .querySelectorAll('input');

            for (let i = 1; i < inputs.length; i++) {
                inputs[i].disabled = true;
            }
        }
    });

}

function CreateCatchCard(catchObj) {
    const div = document.createElement('div');
    div.classList.add('catch');

    const ownerIdField = document.createElement('input');
    ownerIdField.type = 'hidden';
    ownerIdField.value = catchObj._ownerId;

    const anglerLabel = document.createElement('label');
    anglerLabel.textContent = 'Angler';

    const anglerInput = document.createElement('input');
    anglerInput.classList.add('angler');
    anglerInput.value = catchObj.angler;

    const weightLabel = document.createElement('label');
    weightLabel.textContent = 'Weight';

    const weightInput = document.createElement('input');
    weightInput.classList.add('weight');
    weightInput.value = catchObj.weight;

    const speciesLabel = document.createElement('label');
    speciesLabel.textContent = 'Species';

    const speciesInput = document.createElement('input');
    speciesInput.classList.add('species');
    speciesInput.value = catchObj.species;

    const locationLabel = document.createElement('label');
    locationLabel.textContent = 'Location';

    const locationInput = document.createElement('input');
    locationInput.classList.add('location');
    locationInput.value = catchObj.location;

    const baitLabel = document.createElement('label');
    baitLabel.textContent = 'Bait';

    const baitInput = document.createElement('input');
    baitInput.classList.add('bait');
    baitInput.value = catchObj.bait;

    const captureTimeLabel = document.createElement('label');
    captureTimeLabel.textContent = 'Capture Time';

    const captureTimeInput = document.createElement('input');
    captureTimeInput.classList.add('captureTime');
    captureTimeInput.value = catchObj.captureTime;

    const updateBtn = document.createElement('button');
    updateBtn.classList.add('update');
    updateBtn.textContent = 'Update';
    updateBtn.dataset.id = catchObj._id;
    updateBtn.addEventListener('click', UpdateHadler)

    const deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete');
    deleteBtn.textContent = 'Delete';
    deleteBtn.dataset.id = catchObj._id;
    deleteBtn.addEventListener('click', DeleteCatch);

    div.appendChild(ownerIdField);
    div.appendChild(anglerLabel);
    div.appendChild(anglerInput);
    div.appendChild(weightLabel);
    div.appendChild(weightInput);
    div.appendChild(speciesLabel);
    div.appendChild(speciesInput);
    div.appendChild(locationLabel);
    div.appendChild(locationInput);
    div.appendChild(baitLabel);
    div.appendChild(baitInput);
    div.appendChild(captureTimeLabel);
    div.appendChild(captureTimeInput);
    div.appendChild(updateBtn);
    div.appendChild(deleteBtn);

    document.querySelector('#catches').appendChild(div)
}

function UpdateHadler(e) {
    const id = e.target.dataset.id;

    const angler = e.target.parentElement.querySelector('.angler').value;
    const weight = e.target.parentElement.querySelector('.weight').value;
    const species = e.target.parentElement.querySelector('.species').value;
    const location = e.target.parentElement.querySelector('.location').value;
    const bait = e.target.parentElement.querySelector('.bait').value;
    const captureTime = e.target.parentElement.querySelector('.captureTime').value;

    Update(id, angler, weight, species, location, bait, captureTime);
}

function DeleteCatch(e){
    const id = e.target.dataset.id;

    Delete(id);
    e.target.parentElement.remove();
}

async function Delete(id){
    const url = `http://localhost:3030/data/catches/${id}`;

    const response = await fetch(url, {
        method: 'delete',
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": token
        },
    })

    await GetAllCatches()
}

async function Update(id, angler, weight, species, location, bait, captureTime) {
    const url = `http://localhost:3030/data/catches/${id}`;

    const body = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    }

    const response = await fetch(url, {
        method: 'put',
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": token
        },
        body: JSON.stringify(body)
    })

    const data = await response.json();

    await GetAllCatches()
}

async function GetCatchById(id) {
    const url = "http://localhost:3030/data/catches/";

    const response = await fetch(url + id);
    const data = await response.json();

    return data;
}

async function Create(angler, weight, species, location, bait, captureTime) {
    const url = "http://localhost:3030/data/catches";

    const body = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    }

    const response = await fetch(url, {
        method: 'post',
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": token
        },
        body: JSON.stringify(body)
    });

    const data = await response.json();

    await GetAllCatches();
}

async function GetAllCatches(e) {
    const url = "http://localhost:3030/data/catches";

    const response = await fetch(url);
    const data = await response.json();

    LoadCatches(data);
}

async function Logout(e) {
    const url = "http://localhost:3030/users/logout";

    const response = await fetch(url, {
        method: 'get',
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": token
        }
    });

    if (!response.ok) {
        return;
    }

    sessionStorage.clear();

    window.location.href = 'http://127.0.0.1:5500/Remote%20Data%20and%20Authentication/05.Fisher-Game/src/index.html'
}