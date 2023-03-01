import { createItem } from "../api/data.js";
import { createTemplate } from "../templates/template.js";
import { extractFormData } from "../util.js";

let context = null;

export function ShowCreate(ctx){
    context = ctx;

    ctx.render(createTemplate(onSubmit, onValidate))
}

async function onSubmit(e) {
    e.preventDefault();

    const {make, model, year, description, price, img, material} = extractFormData(e.target);

    if (make == '' || model == '' || year == '' || description == '' || price == '' || img == '') {
        alert('All fields are required !');
        return;
    }

    const response = await createItem( {make, model, year, description, price, img, material} );

    context.page.redirect('/');
}

export function onValidate(e){
    const text = e.target.value;
    const label = e.target.name;

    if (label == 'make' || label == 'model') {
        if (text.length < 4) {
            setInvalidClass(e.target);
        } else {
            setValidClass(e.target);
        }
    } else if (label == 'year') {
        if (Number(text) < 1950 || Number(text) > 2050) {
            setInvalidClass(e.target);
        } else {
            setValidClass(e.target);
        }
    } else if (label == 'description') {
        if (text.length < 10) {
            setInvalidClass(e.target);
        } else {
            setValidClass(e.target);
        }
    } else if (label == 'price') {
        if (Number(text) < 0) {
            setInvalidClass(e.target);
        } else {
            setValidClass(e.target);
        }
    } else if (label == 'img'){
        if (text == '') {
            setInvalidClass(e.target);
        } else {
            setValidClass(e.target);
        }
    }
}

function setInvalidClass(input){
    input.classList.remove('is-valid');
    input.classList.add('is-invalid');
}

function setValidClass(input){
    input.classList.remove('is-invalid');
    input.classList.add('is-valid');
}