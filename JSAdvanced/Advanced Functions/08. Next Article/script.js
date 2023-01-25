function getArticleGenerator(articles) {
    const div = document.querySelector('#content');
    return function showNext() {
        let article = document.createElement('article');
        if (articles.length > 0) {
            article.textContent = articles.shift();
            div.appendChild(article);
        }
    }
}