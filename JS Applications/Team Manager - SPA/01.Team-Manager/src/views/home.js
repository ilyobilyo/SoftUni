import { homeTemplate } from "../temlpates/templates.js";

export function ShowHome(ctx){
    ctx.render(homeTemplate(ctx.user.accessToken));
}