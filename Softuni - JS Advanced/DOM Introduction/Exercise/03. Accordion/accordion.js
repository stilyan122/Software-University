function toggle() {
    let accordionWrapper = document.getElementById('accordion');
    let textWrapperTag = document.getElementById('extra');
    let button = accordionWrapper.getElementsByClassName('button')[0];

    if (button.textContent === 'More') {
        textWrapperTag.style.display = 'block';
        button.textContent = 'Less';
    } else {
        textWrapperTag.style.display = 'none';
        button.textContent = 'More';
    }
}