function calculator() {
    let input1 = '';
    let input2 = '';
    let resultInput = '';

    function init(num1, num2, result){
        input1 = document.querySelector(num1);
        input2 = document.querySelector(num2);
        resultInput = document.querySelector(result);
    }

    function add(){
        resultInput.value = Number(input1.value) + Number(input2.value);
    }

    function subtract(){
        resultInput.value = Number(input1.value) - Number(input2.value);
    }

    return {
        init,
        add,
        subtract
    }
}


const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 


