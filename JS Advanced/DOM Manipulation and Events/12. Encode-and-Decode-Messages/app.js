function encodeAndDecodeMessages() {
    let buttons = Array.from(document.querySelectorAll('button'));

    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function encode(e) {
        let text = e.target.parentElement.querySelector('textarea').value;
        let result = '';

        for (let i = 0; i < text.length; i++) {
            result += String.fromCharCode(text.charCodeAt(i) + 1);
        }

        let reciver = e.target
            .parentElement
            .parentElement
            .querySelectorAll('div')[1]
            .querySelector('textarea');

        reciver.value = result;
        e.target.parentElement.querySelector('textarea').value = '';
    }

    function decode(e) {
        let text = e.target.parentElement.querySelector('textarea').value;
        let result = '';

        for (let i = 0; i < text.length; i++) {
            result += String.fromCharCode(text.charCodeAt(i) - 1);
        }

        e.target.parentElement.querySelector('textarea').value = result;
    }
}