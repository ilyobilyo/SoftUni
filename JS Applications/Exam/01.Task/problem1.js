function sovle(input) {
    let n = input.shift();

    let people = {};

    for (let i = 0; i < n; i++) {
        let data = input.shift().split(':');

        let name = data.shift();
        if (people[name]) {
            people[name].push({
                id: data.shift(),
                title: data.shift(),
                status: data.shift(),
                points: data.shift()
            })
        } else {
            people[name] = [{
                id: data.shift(),
                title: data.shift(),
                status: data.shift(),
                points: data.shift()
            }];
        }

    }

    const length = input.length

    for (let i = 0; i < length; i++) {
        let tokens = input.shift().split(':');

        if (tokens[0] == 'Add New') {
            if (people[tokens[1]]) {
                people[tokens[1]].push({
                    id: tokens[2],
                    title: tokens[3],
                    status: tokens[4],
                    points: tokens[5]
                })
            } else {
                console.log(`Assignee ${tokens[1]} does not exist on the board!`);
            }
        } else if (tokens[0] == 'Change Status') {
            if (people[tokens[1]]) {
                let task = people[tokens[1]].find(x => x.id == tokens[2]);

                if (task) {
                    task.status = tokens[3]
                } else {
                    console.log(`Task with ID ${tokens[2]} does not exist for ${tokens[1]}!`);
                }
            } else {
                console.log(`Assignee ${tokens[1]} does not exist on the board!`);
            }
        } else if (tokens[0] == 'Remove Task') {
            if (people[tokens[1]]) {
                if (Number(tokens[2]) >= people[tokens[1]].length || Number(tokens[2]) < 0) {
                    console.log('Index is out of range!');
                } else {
                    people[tokens[1]].splice(Number(tokens[2]), 1)
                }
            } else {
                console.log(`Assignee ${tokens[1]} does not exist on the board!`);
            }
        }
    }

    let todos = 0;
    let inProgress = 0;
    let codeReview = 0;
    let done = 0;
    let totalUncomleted = 0;


    for (const key in people) {
        people[key].forEach(x => {
            if (x.status == 'ToDo') {
                todos += Number(x.points);
                totalUncomleted += Number(x.points);

            } else if(x.status == 'In Progress'){
                inProgress += Number(x.points)
                totalUncomleted += Number(x.points);

            } else if(x.status == 'Code Review') {
                codeReview += Number(x.points)
                totalUncomleted += Number(x.points);

            } else if (x.status == 'Done'){
                done += Number(x.points)
                
            }
        });
    }

    console.log(`ToDo: ${todos}pts`);
    console.log(`In Progress: ${inProgress}pts`);
    console.log(`Code Review: ${codeReview}pts`);
    console.log(`Done Points: ${done}pts`);

    if (done >= totalUncomleted) {
        console.log('Sprint was successful!');
    } else{
        console.log('Sprint was unsuccessful...');
    }
}

sovle([
    '4',
    'Kiril:BOP-1213:Fix Typo:Done:1',
    'Peter:BOP-1214:New Products Page:In Progress:2',
    'Mariya:BOP-1215:Setup Routing:ToDo:8',
    'Georgi:BOP-1216:Add Business Card:Code Review:3',
    'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
    'Change Status:Georgi:BOP-1216:Done',
    'Change Status:Will:BOP-1212:In Progress',
    'Remove Task:Georgi:3',
    'Change Status:Mariya:BOP-1215:Done',
]
)
