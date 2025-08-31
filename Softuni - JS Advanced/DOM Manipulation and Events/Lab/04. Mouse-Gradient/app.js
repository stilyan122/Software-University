function attachGradientEvents() {
    let gradient = document.getElementById('gradient');
    let result = document.getElementById('result');

    gradient.addEventListener('mousemove', function(e) {
        let gradientRect = gradient.getBoundingClientRect();
        let x = e.clientX - gradientRect.left;  // Get the mouse position relative to the gradient element.
        let percentage = Math.floor((x / gradientRect.width) * 100); // Calculate the percentage.

        result.textContent = `${percentage}%`;  // Display the percentage.
    });
}