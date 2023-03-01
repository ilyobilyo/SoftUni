import { getById } from "../api/data.js";
import { detailsTemplate } from "../templates/template.js";

export async function ShowDetails(ctx){
    const item = await getById(ctx.params.id);
    const isOwner = checkOwner(item);
    item.img = item.img.split('/')[2];

    ctx.render(detailsTemplate(item, isOwner))
}

function checkOwner(item){
    if (item._ownerId == sessionStorage.getItem('id')) {
        return true;
    } else {
        return false;
    }
}