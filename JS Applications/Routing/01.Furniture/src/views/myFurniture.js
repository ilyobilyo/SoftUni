import { GetMyItems } from "../api/data.js";
import { dashboardTemplate } from "../templates/template.js";

export async function ShowMyCollection(ctx){
    const myItems = await GetMyItems(sessionStorage.getItem('id'));

    ctx.render(dashboardTemplate(myItems));
}