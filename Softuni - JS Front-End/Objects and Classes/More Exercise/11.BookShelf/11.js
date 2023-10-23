function bookshelf(input){
    class Shelf{
        constructor(id,genre){
            this.id = id,
            this.genre = genre,
            this.books = []
        }
    }
    class Book{
        constructor(title,author,genre){
            this.title = title,
            this.author = author,
            this.genre = genre
        }
    }
    let shelves = [];
    input.reduce((acc,curr)=>
    {
        if(curr.includes('->')){
            const id = curr.split(' -> ')[0];
            const genre = curr.split(' -> ')[1];
            if(shelves.find((shelf)=>shelf.id===id)===undefined){
                const shelf = new Shelf(id,genre);
                shelves.push(shelf);
            }
        }
        else{
            const title = curr.split(': ')[0];
            const author = curr.split(': ')[1].split(', ')[0];
            const genre = curr.split(': ')[1].split(', ')[1];
            const book = new Book(title,author,genre);
            if(shelves.find((shelf)=>shelf.genre===genre)!==undefined){
                shelves.find((shelf)=>shelf.genre===genre).books.push(book);
            }
        }
        return shelves;
    }
    ,[]).sort((a,b)=>b.books.length - a.books.length).forEach((shelf)=>{
        console.log(`${shelf.id} ${shelf.genre}: ${shelf.books.length}`);
        shelf.books.sort((a,b) => a.title - b.title).forEach((book)=>{
            console.log(`--> ${book.title}: ${book.author}`);
        })
    })
}