import { getAll } from "../api/data.js";
import { dashboardTemplate } from "../templates/template.js";

export async function ShowDashboard(ctx){
    const furniture = await getAll();

    ctx.render(dashboardTemplate(furniture))
}