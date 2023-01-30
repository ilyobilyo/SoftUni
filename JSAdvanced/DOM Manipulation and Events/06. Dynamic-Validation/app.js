function validate() {
    const element = document.getElementById('email');
    element.addEventListener('change', validateEmail);

    function validateEmail(e){
        let email = element.value;
        const pattern = /^[a-z]*@[a-z]*.[a-z]*$/g;
        let match = pattern.exec(email);

        if(match){
            element.classList.remove('error');
        }else{
            element.classList.add('error');
        }
    }
}