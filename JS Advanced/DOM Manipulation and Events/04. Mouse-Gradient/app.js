function attachGradientEvents() {
    const element = document.querySelector('#gradient');
    element.addEventListener('mousemove', mouseIn)
    element.addEventListener('mouseout', mouseOut)

    function mouseIn(ev) {
        let width = element.clientWidth;
        let mousePosition = ev.offsetX;
        document.getElementById('result').textContent = Math.floor((mousePosition / width) * 100) + '%'
    }

    function mouseOut() {
        document.getElementById('result').textContent = '';
    }
}