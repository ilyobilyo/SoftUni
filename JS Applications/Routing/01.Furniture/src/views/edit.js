import { getById, update } from "../api/data.js";
import { editTemplate } from "../templates/template.js";
import { extractFormData } from "../util.js";
import { onValidate } from "./create.js";

let context = null;

export async function ShowEdit(ctx){
    context = ctx;
    const item = await getById(ctx.params.id);

    ctx.render(editTemplate(item, onSubmit, onValidate));
}

async function onSubmit(e){
    e.preventDefault();

    const itemId = e.submitter.dataset.id;

    const {make, model, year, description, price, img, material} = extractFormData(e.target);

    if (make == '' || model == '' || year == '' || description == '' || price == '' || img == '') {
        alert('All fields are required !');
        return;
    }

    const response = await update(itemId, {make, model, year, description, price, img, material} );

    context.page.redirect('/details/' + itemId);
}