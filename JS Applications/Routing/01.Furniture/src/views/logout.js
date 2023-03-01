import { logout } from "../api/data.js";

export async function onLogout(ctx){
    await logout();

    ctx.updateNav();
    ctx.page.redirect('/');
}