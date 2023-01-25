function solve(commands) {
    let result = [];

    for (const cmndData of commands) {
        let [cmnd, string] = cmndData.split(' ');

        switch (cmnd) {
            case 'add':
                add(string);
                break;
            case 'remove':
                remove(string);
                break;
            case 'print':
                print();
                break;
        }
    }

    function add(string) {
        result.push(string);
    }

    function remove(string) {
       result = result.filter(x => x !== string);
    }

    function print(){
        console.log(result.join(','));
    }
}

solve(['add pesho', 'add george', 'add peter','add peter', 'remove peter','print']);