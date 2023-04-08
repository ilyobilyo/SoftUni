function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/tasks';

    document.getElementById('load-board-btn').addEventListener('click', loadTasks);
    document.getElementById('create-task-btn').addEventListener('click', addTask);

    const sections = {
        todo: document.getElementById('todo-section'),
        inProgress: document.getElementById('in-progress-section'),
        codeReview: document.getElementById('code-review-section'),
        done: document.getElementById('done-section'),
    }

    const inputs = {
        title: document.getElementById('title'),
        description: document.getElementById('description'),
    }

    const btnsTexts = {
        'ToDo': 'Move to In Progress',
        'In Progress': 'Move to Code Review',
        'Code Review': 'Move to Done',
        'Done': 'Close'
    }

    async function loadTasks() {
        const res = await fetch(url);
        const data = await res.json();

        for (const key in sections) {
            sections[key].querySelectorAll('li').forEach(x => {
                x.remove();
            });
        }

        Object.values(data).forEach(t => {
            let li = createElement(t);

            if (t.status == 'ToDo') {
                sections.todo.querySelector('.task-list').appendChild(li);

            } else if (t.status == 'In Progress') {
                sections.inProgress.querySelector('.task-list').appendChild(li);

            } else if (t.status == 'Code Review') {
                sections.codeReview.querySelector('.task-list').appendChild(li);

            } else if (t.status == 'Done') {
                sections.done.querySelector('.task-list').appendChild(li);

            }
        })
    }

    async function addTask() {
        if (inputs.title.value !== '' && inputs.description.value !== '') {
            const res = await fetch(url, {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ title: inputs.title.value, description: inputs.description.value, status: 'ToDo' })
            })

            inputs.title.value = '';
            inputs.description.value = '';
            const data = await res.json();

            await loadTasks();
        }
    }

    async function moveTask(e) {
        let task = e.target.parentElement;
        let currSectionId = e.target.parentElement.parentElement.parentElement.id;
        let status = '';

        if (currSectionId == 'done-section') {
            const res = await fetch(`${url}/${e.target.dataset.id}`, {
                method: 'delete'
            })

            const data = res.json();

            await loadTasks();
        } else {
            if (currSectionId == 'todo-section') {
                status = 'In Progress';
            } else if (currSectionId == 'in-progress-section') {
                status = 'Code Review';
            } else if (currSectionId == 'code-review-section') {
                status = 'Done';
            }

            const res = await fetch(`${url}/${e.target.dataset.id}`, {
                method: 'PATCH',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ status })
            });

            const data = await res.json();

            await loadTasks();
        }

    }

    function createElement(task) {
        let li = document.createElement('li');
        li.classList.add('task');

        let title = document.createElement('h3');
        title.textContent = task.title;

        let desc = document.createElement('p');
        desc.textContent = task.description;

        let btn = document.createElement('button');
        btn.dataset.id = task._id;
        btn.textContent = task.status == 'Done' ? btnsTexts['Done'] : btnsTexts[task.status];
        btn.addEventListener('click', moveTask);

        li.appendChild(title);
        li.appendChild(desc);
        li.appendChild(btn);

        return li;
    }
}

attachEvents();