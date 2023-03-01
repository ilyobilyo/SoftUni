import { deleteItem } from "../api/data.js";

export async function onDelete(ctx){
    await deleteItem(ctx.params.id);

    ctx.page.redirect('/');
}