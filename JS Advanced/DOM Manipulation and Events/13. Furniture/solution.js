function solve() {
  let buttons = document.querySelectorAll('button');
  buttons[0].addEventListener('click', generate);
  buttons[1].addEventListener('click', buy);

  function generate(e) {
    let json = e.target.parentElement.querySelectorAll('textarea')[0].value;
    let objects = JSON.parse(json);

    let tbdoy = document.querySelector('tbody');

    for (const obj of objects) {
      let tr = document.createElement('tr');

      let td1 = document.createElement('td');
      let img = document.createElement('img');
      img.src = obj.img;

      td1.appendChild(img);
      tr.appendChild(td1);

      let td2 = document.createElement('td');
      let p1 = document.createElement('p');
      p1.textContent = obj.name;

      td2.appendChild(p1);
      tr.appendChild(td2);

      let td3 = document.createElement('td');
      let p2 = document.createElement('p');
      p2.textContent = obj.price;

      td3.appendChild(p2);
      tr.appendChild(td3);

      let td4 = document.createElement('td');
      let p3 = document.createElement('p');
      p3.textContent = obj.decFactor;

      td4.appendChild(p3);
      tr.appendChild(td4);

      let td5 = document.createElement('td');
      let input = document.createElement('input');
      input.type = 'checkbox';

      td5.appendChild(input);
      tr.appendChild(td5);

      tbdoy.appendChild(tr);
    }
  }

  function buy(e) {
    let checkboxes = Array.from(document.querySelectorAll('input[type="checkbox"]')).filter(x => x.disabled == false);
    let names = [];
    let sum = 0;
    let decFactorSum = 0;
    let result = '';

    for (const chkBox of checkboxes) {
      if(chkBox.checked){
        let tds = chkBox.parentElement.parentElement.querySelectorAll('td');

        names.push(tds[1].children[0].textContent);
        sum += Number(tds[2].children[0].textContent);
        decFactorSum += Number(tds[3].children[0].textContent);
      }
    }

    result += `Bought furniture: ${names.join(', ')}\n`;
    result += `Total price: ${sum.toFixed(2)}\n`;
    result += `Average decoration factor: ${decFactorSum / names.length}`;
    
    e.target.parentElement.querySelectorAll('textarea')[1].value = result;
  }
}