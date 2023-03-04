import { ApproveMemberById, CreateTeam, JoinTeam } from "../api/data.js";
import { createTeamTemplate } from "../temlpates/teamTemplates.js";
import { extractFormData } from "../util.js";

let context = null;

export function ShowCreate(ctx){
    if (!context) {
        context = ctx;
    }

    ctx.render(createTeamTemplate(onSubmit, context.params.message));

    if (context.params.message) {
        context.params.message = null
    } 
}

async function onSubmit(e){
    e.preventDefault();

    const {name, logoUrl, description} = extractFormData(e.target);

    if (name.length < 4) {
        context.params.message = 'Name must be at least 4 characters';
        ShowCreate(context);
        return;
    }

    if (logoUrl == '') {
        context.params.message = 'logoUrl is required';
        ShowCreate(context);
        return;
    }

    if (description.length < 10) {
        context.params.message = 'Description must be at least 10 characters';
        ShowCreate(context);
        return;
    }

    try {
        const response = await CreateTeam( {name, logoUrl, description} );
        const joinRes = await JoinTeam( {teamId: response._id} );

        joinRes.status = 'member';

        await ApproveMemberById(joinRes._id, joinRes);
        e.target.reset();
        context.page.redirect(`/details/${response._id}`);
    } catch (error) {
        context.params.message = error.message;
        ShowCreate(context);
        return;
    }
}