function getArticleGenerator(articles) {
    return () => {
        let content = document.getElementById('content');
        
        if (articles.length > 0) {
            let article = document.createElement('article');
            article.textContent = articles.shift();
            content.appendChild(article);
        }
    }
}
