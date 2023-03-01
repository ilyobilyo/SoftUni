function generateReport() {
    const inputFields = document.querySelectorAll('input');
    const tableData = document.querySelectorAll('tr');
    let colNames = [];
    let indexes = [];
    let result = {};
    let output = [];

    for(let i = 0; i < inputFields.length; i++){
        if(inputFields[i].checked){
            result[inputFields[i].name] = '';
            indexes.push(i);
            colNames.push(inputFields[i].name);
        }
    }

    for(let i = 1; i < tableData.length; i++){
        const tr = tableData[i].children;
        const currResult = Object.assign({}, result);
        for(let j = 0; j < colNames.length; j++){
            currResult[colNames[j]] = tr[indexes[j]].textContent;
        }

        output.push(currResult);
    }

    document.querySelector('#output').value = JSON.stringify(output);
}