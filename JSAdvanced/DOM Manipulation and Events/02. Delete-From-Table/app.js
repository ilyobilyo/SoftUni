function deleteByEmail() {
    const emailToDel = document.querySelector('input[name="email"]').value;
    const allMails = document.querySelectorAll('tr');
    let isFound = false;

    for(let i = 1; i < allMails.length; i++){
        if(allMails[i].children[1].textContent == emailToDel){
            allMails[i].remove();
            isFound = true;
        }
    }

    document.getElementById('result').textContent = isFound ? 'Deleted.' : 'Not found.';
    
    document.querySelector('input[name="email"]').value = '';
}