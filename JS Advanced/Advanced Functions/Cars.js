function solve(input) {
    let result = [];
    let object = {};

    for (const cmndData of input) {
        let commandArray = cmndData.split(' ');
        let command;

        if(commandArray[2] === 'inherit'){
            command = 'inherit';
        }else{
            command = commandArray[0];
        }

        switch (command) {
            case 'create':
                create(commandArray[1]);
                break;
            case 'inherit':
                createInherit(commandArray[1], commandArray[3])
                break;
            case 'set':
                set(commandArray[1], commandArray[2], commandArray[3])
                break;
            case 'print':
                break;
        }
    }

    function create(name) {
        let obj = {
            name: name
        };

        result.push(obj);
    }

    function createInherit(name, parentName) {
        let obj = {
            name: name
        };

        let parent = result.find(x => x.name === parentName);

        result.push(obj);
    }

    function set(name, key, value) {
        let obj = result.find(x => x.name === name);
        obj[key] = value;
    }

    function print(name) {

    }
}


solve(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
])