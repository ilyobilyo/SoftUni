import { AllTeamsPages, GetAllMembersCountFromTeam, GetMyMemberships, GetMyMembershipsCount } from "../api/data.js";
import { createMyTeamsTemplate } from "../temlpates/teamTemplates.js";

export async function ShowMyTeams(ctx){
    let page = Number(ctx.query.page) || 1;

    const myMemberships = await GetMyMemberships(page, sessionStorage.getItem('id'));
    let myTeams = [];

    for (const mempership of myMemberships) {
        const allMembers = await GetAllMembersCountFromTeam(mempership.teamId);
        mempership.team.membersCount = allMembers.filter(x => x.status == 'member').length;
        myTeams.push(mempership.team);
    }

    const allMembershipsCount = await GetMyMembershipsCount(sessionStorage.getItem('id'));

    const myTeamsAllPages = AllTeamsPages(allMembershipsCount);

    ctx.render(createMyTeamsTemplate(myTeams, page, myTeamsAllPages));
}