import { del, get, post, put } from "./api.js";

const endpoints = {
    'teams': '/data/teams',
    'members': '/data/members',
}

const pageSize = 3;

export async function GetAllTeams(pageNumber){
    if (pageNumber) {
        const url = teamsPagination(pageNumber);

        return await get(url);
    } else {
        return await get(endpoints.teams);
    }

}

export async function GetTeamById(id){
    return await get(`${endpoints.teams}/${id}`);
}

export async function GetMyMemberships(pageNumber, userId){
    let url = teamsPagination(pageNumber, true);
    url += '&' + composeMyTeamsUrl(userId);
    return await get(url);
}

export async function GetAllMembers(){
    return await get(endpoints.members);
}

export async function GetMemberById(id){
    return await get(`${endpoints.members}/${id}`);
}

export async function GetMyMembershipsCount(userId){
    let url = '?' + composeMyTeamsUrl(userId) + '&count';

    return await get(endpoints.members + url);
}

export async function GetAllMembersCount(){
    const url = membersQuery(null);

    return await get(url);
}

export async function GetAllMembersByTeamId(teamId){
    const url = membersQuery(teamId);

    return await get(url);
}

export async function JoinTeam(body){
    return await post(endpoints.members, body)
}

export async function GetAllMembersCountFromTeam(teamId){
    const url = membersQuery(teamId);

    return await get(url);
}

export async function CreateTeam(body){
    return await post(endpoints.teams, body);
}

export async function EditTeam(id, body){
    return await put(`${endpoints.teams}/${id}`, body);
}

export async function ApproveMemberById(id, body){
    return await put(`${endpoints.members}/${id}`, body);
}

export async function DeclineMemberById(id){
    return await del(`${endpoints.members}/${id}`);
}

function membersQuery(teamId){
    let url = endpoints.members;

    if (teamId) {
        url += `?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`;
    } 

    return url;
}

function teamsPagination(pageNumber, myTeams){
    let url;

    myTeams ? url = endpoints.members : url = endpoints.teams;

    let skip = (pageNumber - 1) * pageSize;

    url += `?offset=${skip}&pageSize=${pageSize}`;

    return url;
}

function composeMyTeamsUrl(userId){
    return `where=_ownerId%3D%22${userId}%22%20AND%20status%3D%22member%22&load=team%3DteamId%3Ateams`;
}

export async function GetAllTeamsCount(){
    const url = endpoints.teams + '?count';

    return await get(url);
}

export function AllTeamsPages(count){
    return Math.ceil(count / pageSize);
}