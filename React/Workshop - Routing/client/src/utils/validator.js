
export const validatePssword = (password) => {
    if (password.length < 4) {
        return 'Password must be at least 4 characters long';
    } else {
        return '';
    }
}

export const validateConfirmPssword = (password, confirmPassword) => {
    if (password !== confirmPassword) {
        return 'Password and confirm password dont match';
    } else {
        return '';
    }
}

export const validateEmail = (email) => {
    if (email.length === 0) {
        return 'Email is required';
    } else {
        return '';
    }
}

export const validateGameField = (fieldName, value) => {
    if (value.length === 0) {
        return `${fieldName} is required !`;
    } else {
        return '';
    }
}

export const validateGameMaxLevel = (value) => {
    if (value < 1) {
        return 'Game maximum level must be more than zero'
    } else {
        return '';
    }
}