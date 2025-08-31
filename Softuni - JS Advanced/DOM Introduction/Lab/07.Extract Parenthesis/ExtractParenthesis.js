function extract(content) {
    let element = document.getElementById(content);
    let text = element.textContent;
    let matches = [...text.matchAll(/\([^)]+\)/g)].map(match => match[0]);

    let expressions = [];

    matches.forEach((match) => {
        expressions.push(match.slice(1, match.length - 1));
    });

    return expressions.join('; ');
}