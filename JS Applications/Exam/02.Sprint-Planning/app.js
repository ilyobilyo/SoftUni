window.addEventListener('load', solve);

function solve() {
    const inputs = {
        title: document.getElementById('title'),
        description: document.getElementById('description'),
        label: document.getElementById('label'),
        points: document.getElementById('points'),
        assignee: document.getElementById('assignee'),
        id: document.getElementById('task-id'),
    }

    const otherElements = {
        createBtn: document.getElementById('create-task-btn'),
        deleteBtn: document.getElementById('delete-task-btn'),
        taskSection: document.getElementById('tasks-section'),
        totalSprintPoints: document.getElementById('total-sprint-points'),
        form: document.getElementById('create-task-form'),
    }

    const symbols = {
        Feature: '&#8865;',
        'Low Priority Bug': '&#9737;',
        'High Priority Bug': '&#9888;'
    }

    const additionalClasses = {
        'Feature': 'feature',
        'Low Priority Bug': 'low-priority',
        'High Priority Bug': 'high-priority'
    }

    const tasks = []

    let countTasks = 1;
    let totalPoints = 0;

    otherElements.createBtn.addEventListener('click', addTask);
    otherElements.deleteBtn.addEventListener('click', deleteTask);


    function addTask(e) {
        e.preventDefault();

        if (inputs.title.value == '' || inputs.description.value == '' || inputs.label.value == ''
            || inputs.points.value == '' || inputs.assignee.value == '') {
            return;
        }

        const article = createArticle();

        otherElements.taskSection.appendChild(article);

        totalPoints += Number(inputs.points.value);

        otherElements.totalSprintPoints.textContent = `Total Points ${totalPoints}pts`;

        tasks.push({
            id: `task-${countTasks}`,
            title: inputs.title.value,
            description: inputs.description.value,
            label: inputs.label.value,
            points: inputs.points.value,
            assignee: inputs.assignee.value
        })

        countTasks++;

        inputs.title.value = '';
        inputs.description.value = '';
        inputs.label.value = '';
        inputs.points.value = '';
        inputs.assignee.value = '';

    }

    function deleteTaskCofirmation(e) {
        e.preventDefault();

        let taskToDel = tasks.find(x => x.id == e.target.parentElement.parentElement.id);

        for (const key in inputs) {
            inputs[key].value = taskToDel[key];
            inputs[key].disabled = true;
        }

        otherElements.deleteBtn.disabled = false;
        otherElements.createBtn.disabled = true;


    }
    
    function deleteTask(e) {
        e.preventDefault();

        document.querySelector(`article[id="${inputs.id.value}"]`).remove();

        totalPoints -= Number(inputs.points.value);
        otherElements.totalSprintPoints.textContent = `Total Points ${totalPoints}pts`;
        
        for (const key in inputs) {
            inputs[key].value = '';
            inputs[key].disabled = false;
        }

        otherElements.deleteBtn.disabled = true;
        otherElements.createBtn.disabled = false;
    }


    function createArticle() {
        let article = document.createElement('article');
        article.id = `task-${countTasks}`;
        article.classList.add('task-card');

        let labelDiv = document.createElement('div');
        labelDiv.classList.add('task-card-label');
        labelDiv.classList.add(additionalClasses[inputs.label.value]);
        labelDiv.innerHTML = `${inputs.label.value} ${symbols[inputs.label.value]}`;

        let title = document.createElement('h3');
        title.classList.add('task-card-title');
        title.textContent = inputs.title.value;

        let desc = document.createElement('p');
        desc.classList.add('task-card-description');
        desc.textContent = inputs.description.value;

        let pointsDiv = document.createElement('div');
        pointsDiv.classList.add('task-card-points');
        pointsDiv.textContent = `Estimated at ${inputs.points.value} pts`;

        let assigneeDiv = document.createElement('div');
        assigneeDiv.classList.add('task-card-assignee');
        assigneeDiv.textContent = `Assigned to: ${inputs.assignee.value}`;

        let actionsDiv = document.createElement('div');
        actionsDiv.classList.add('task-card-actions');

        let delBtn = document.createElement('button');
        delBtn.addEventListener('click', deleteTaskCofirmation);
        delBtn.textContent = 'Delete';

        actionsDiv.appendChild(delBtn);

        article.appendChild(labelDiv);
        article.appendChild(title);
        article.appendChild(desc);
        article.appendChild(pointsDiv);
        article.appendChild(assigneeDiv);
        article.appendChild(actionsDiv);

        return article;
    }
}