import { ApproveMemberById, DeclineMemberById, GetAllMembersByTeamId, GetMemberById, GetTeamById, JoinTeam } from "../api/data.js";
import { createDetailsTemplate } from "../temlpates/teamTemplates.js";
import { getUserData } from "../util.js";

let context = null;

export async function ShowDetails(ctx){
    context = ctx;

    const team = await GetTeamById(ctx.params.id);
    const allMembers = await GetAllMembersByTeamId(ctx.params.id);

    const members = allMembers.filter(x => x.status == 'member');
    const pendingMembers = allMembers.filter(x => x.status == 'pending');

    const owner = members.find(x => x._ownerId == team._ownerId).user;

    const user = getUserData();

    team.members = members;
    team.pendings = pendingMembers;

    checkUserIsOwner(user, team);
    checkUserIsMember(user, members);
    checkUserIsPending(user, pendingMembers);

    ctx.render(createDetailsTemplate(team, user, onJoin, onApprove, cancelMembership, owner))
}

async function onJoin(e){
    e.preventDefault();

    const response = await JoinTeam({teamId: context.params.id});

    context.page.redirect(`/details/${context.params.id}`);
}

async function cancelMembership(e){
    e.preventDefault();

    const member = await GetMemberById(e.target.dataset.id);

    await DeclineMemberById(e.target.dataset.id);

    context.page.redirect(`/details/${context.params.id}`);
}

async function onApprove(e){
    e.preventDefault();

    const member = await GetMemberById(e.target.dataset.id);

    member.status = 'member';

    const response = await ApproveMemberById(e.target.dataset.id, member);

    context.page.redirect(`/details/${context.params.id}`);
}

function checkUserIsOwner(user, team){
    if (user.id == team._ownerId) {
        user.isOwner = true;
    } else {
        user.isOwner = false;
    }
}

function checkUserIsMember(user, members){
    if (members.some(x => x._ownerId == user.id)) {
        user.isMember = true;
    } else {
        user.isMember = false;
    }
}

function checkUserIsPending(user, pendingMembers){
    if (pendingMembers.some(x => x._ownerId == user.id)) {
        user.isPending = true;
    } else {
        user.isPending = false;
    }
}