import { EditTeam, GetTeamById } from "../api/data.js";
import { createEditTemplate } from "../temlpates/teamTemplates.js";
import { extractFormData } from "../util.js";

let context = null;

export async function ShowEdit(ctx){
    context = ctx;

    const team = await GetTeamById(ctx.params.id);

    ctx.render(createEditTemplate(team, onSubmit, context.params.message));

    if (context.params.message) {
        context.params.message = null
    }
}

async function onSubmit(e){
    e.preventDefault();

    const {name, logoUrl, description} = extractFormData(e.target);

    if (name.length < 4) {
        context.params.message = 'Name must be at least 4 characters';
        ShowEdit(context);
        return;
    }

    if (logoUrl == '') {
        context.params.message = 'logoUrl is required';
        ShowEdit(context);
        return;
    }

    if (description.length < 10) {
        context.params.message = 'Description must be at least 10 characters';
        ShowEdit(context);
        return;
    }

    try {
        const response = await EditTeam(context.params.id, {name, logoUrl, description} );
        e.target.reset();
    } catch (error) {
        context.params.message = error.message;
        ShowEdit(context);
        return;
    }

    context.page.redirect(`/details/${context.params.id}`);
}