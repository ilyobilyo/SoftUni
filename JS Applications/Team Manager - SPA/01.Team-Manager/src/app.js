import page from "../node_modules/page/page.mjs";
import { ShowHome } from "./views/home.js";
import { onLogout } from "./util.js";
import { ShowRegister } from "./views/register.js";
import { ShowLogin } from "./views/login.js";
import { ShowTeams } from "./views/teams.js";
import { ShowCreate } from "./views/createTeam.js";
import { ShowDetails } from "./views/details.js";
import { ShowEdit } from "./views/edit.js";
import { ShowMyTeams } from "./views/myTeams.js";
import { queryParseMiddleware, renderMiddleware, setUserMiddleware, updateNav } from "./middlewares.js";

page(setUserMiddleware)
page(queryParseMiddleware)
page(renderMiddleware)
page('/', ShowHome)
page('/register', ShowRegister)
page('/login', ShowLogin)
page('/logout', onLogout)
page('/teams', ShowTeams)
page('/create', ShowCreate)
page('/details/:id', ShowDetails)
page('/edit/:id', ShowEdit)
page('/myTeams', ShowMyTeams)

updateNav();
page.start();