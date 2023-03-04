import { AllTeamsPages, GetAllMembersCountFromTeam, GetAllTeams, GetAllTeamsCount } from "../api/data.js";
import { browseTeamsTemplate } from "../temlpates/teamTemplates.js";

let context = null;

export async function ShowTeams(ctx){
    context = ctx;
    let page = Number(context.query.page) || 1;
    
    const teams = await GetAllTeams(page);

    for (const team of teams) {
        const allMembers = await GetAllMembersCountFromTeam(team._id);
        team.membersCount = allMembers.filter(x => x.status == 'member').length
    }
    
    const allTeamsCount = await GetAllTeamsCount();

    const allPages = AllTeamsPages(allTeamsCount);

    context.render(browseTeamsTemplate(teams, page, allPages, sessionStorage.getItem('accessToken')));
}