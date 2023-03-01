function solve() {
    let sections = document.querySelectorAll('section');
    let taskInput = document.querySelector('#task');
    let descriptionInput = document.querySelector('#description');
    let dateInput = document.querySelector('#date');

    document.querySelector('#add').addEventListener('click', addTask);


    function addTask(e) {
        e.preventDefault();
        if (taskInput.value !== '' ||
            descriptionInput.value !== '' ||
            dateInput.value !== '') {
            let currElement = createElement('article', 'orange');
            sections[1].children[1].appendChild(currElement);

            taskInput.value = '';
            descriptionInput.value = '';
            dateInput.value = '';
        }
    }

    function deleteTask(e) {
        e.target.parentElement.parentElement.remove();
    }

    function startTask(e) {
        let article = e.target.parentElement.parentElement;
        e.target.remove();

        let finishBtn = document.createElement('button');
        finishBtn.textContent = 'Finish';
        finishBtn.classList.add('orange');
        finishBtn.addEventListener('click', finishTask);

        article.children[3].appendChild(finishBtn)
        sections[2].children[1].appendChild(article);
    }

    function finishTask(e) {
        let article = e.target.parentElement.parentElement;

        e.target.parentElement.remove();
        sections[3].children[1].appendChild(article);
    }


    function createElement(tag, className) {
        let article = document.createElement(tag);

        let h3 = document.createElement('h3')
        h3.textContent = taskInput.value;

        let desc = document.createElement('p');
        desc.textContent = `Description: ${descriptionInput.value}`;

        let date = document.createElement('p');
        date.textContent = `Due Date: ${dateInput.value}`;

        let div = document.createElement('div');
        div.classList.add('flex');

        if (className == 'orange') {
            let deleteBtn = document.createElement('button');
            let startBtn = document.createElement('button');

            deleteBtn.classList.add('red');
            startBtn.classList.add('green');

            deleteBtn.textContent = 'Delete';
            startBtn.textContent = 'Start';

            deleteBtn.addEventListener('click', deleteTask);
            startBtn.addEventListener('click', startTask);

            div.appendChild(startBtn);
            div.appendChild(deleteBtn);
        }

        article.appendChild(h3);
        article.appendChild(desc);
        article.appendChild(date);
        article.appendChild(div);

        return article;
    }
}