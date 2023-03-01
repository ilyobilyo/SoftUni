async function solution() {
    const headingsUrl = "http://localhost:3030/jsonstore/advanced/articles/list";
    const hiddenInfoUrl = "http://localhost:3030/jsonstore/advanced/articles/details/";

    const mainSection = document.querySelector('#main');

    const headingsResponse = await fetch(headingsUrl);
    const headingsData = await headingsResponse.json();

    for (let i = 0; i < headingsData.length; i++) {
        CreateDiv(headingsData[i]);
    }

    function CreateDiv(data){
        let mainDiv = document.createElement('div');
        mainDiv.classList.add('accordion');

        let headDiv = document.createElement('div');
        headDiv.classList.add('head');

        let headSpan = document.createElement('span');
        headSpan.textContent = data.title;

        let btn = document.createElement('button');
        btn.addEventListener('click', onClick);
        btn.classList.add('button');
        btn.id = data._id;
        btn.textContent = 'More';

        headDiv.appendChild(headSpan);
        headDiv.appendChild(btn);

        mainDiv.appendChild(headDiv);

        mainSection.appendChild(mainDiv);

        async function onClick(e){
            let existedExstraDiv = e.target.parentElement.parentElement.querySelector('.extra');

            if (existedExstraDiv) {
                if (e.target.textContent === 'More') {
                    existedExstraDiv.style.display = 'block';
                    btn.textContent = 'Less';
                }else{
                    existedExstraDiv.style.display = 'none';
                    btn.textContent = 'More';
                }

            }else{
                const extraDiv = document.createElement('div');
                extraDiv.classList.add('extra');
                extraDiv.style.display = 'block';
    
                const extraResponse = await fetch(hiddenInfoUrl + data._id);
                const extraData = await extraResponse.json();
    
                const p = document.createElement('p');
                p.textContent = extraData.content;
    
                btn.textContent = 'Less';
    
                extraDiv.appendChild(p);
                mainDiv.appendChild(extraDiv);
            }
            
        }
    }
}

solution();