function colorize() {
    let even = Array.from(document.querySelectorAll("body > table > tbody > tr:nth-child(2n)"));
    for (const el of even) {
        el.style.backgroundColor="Teal";
    }
}