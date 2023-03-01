import { ShowCreate } from "./create.js";
import { ShowDashboard } from "./dashboard.js";
import { ShowDetails } from "./details.js";
import { ShowHome } from "./Home.js";
import { ShowLogin } from "./login.js";
import { ShowRegister } from "./register.js";
import { initialize } from "./router.js";
import { Logout } from "./util.js";

const links = {
    '/': ShowHome,
    '/Register': ShowRegister,
    '/Login': ShowLogin,
    '/Logout': Logout,
    '/Dashboard': ShowDashboard,
    '/Details': ShowDetails,
    '/Create': ShowCreate
}

const router = initialize(links);
router.updateNav();
router.goto('/');