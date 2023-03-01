export function extractFormData(form){
    const formData = new FormData(form);
    const formObj = Object.fromEntries(formData);

    form.reset();
    return formObj;
}