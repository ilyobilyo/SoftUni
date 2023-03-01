function solve() {
  let text = document.querySelector('#text').value;
  let array = text.split(' ');
  let caseName = document.querySelector('#naming-convention').value;
  let result = [];
  switch(caseName){
    case 'Pascal Case':{
      for(let i = 0; i < array.length; i++){
        let word = array[i].toLowerCase();
        word = array[i].charAt(0).toUpperCase() + word.slice(1);
        result.push(word);
      }
      break;
    }
    case 'Camel Case':{
      for(let i = 0; i < array.length; i++){
        let word = array[i].toLowerCase();
        if(i === 0){
          word = array[i].charAt(0).toLowerCase() + word.slice(1);
        }else{
          word = array[i].charAt(0).toUpperCase() + word.slice(1);
        }
        result.push(word);
      }
      break;
    }
    default:{
      result.push('Error!');
    }
  }
  document.querySelector('#result').textContent = result.join('');
}