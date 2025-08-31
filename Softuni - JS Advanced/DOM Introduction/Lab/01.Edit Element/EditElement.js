function editElement(element, oldValue, newValue) {
    while (element.textContent.includes(oldValue)) {
        element.textContent = element.textContent.replace(oldValue, newValue);
    }
}