const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server.js');

const { expect } = chai;

chai.use(chaiHttp);

describe('Books API', () => {
    let bookId;

    // Verify Posting a Book
    it('should POST a book', (done) => {
        const book = { id: "1", title: "Test Book", author: "Test Author" };

        chai.request(server)
            .post('/books')
            .send(book)
            .end((err, res) => {
                expect(res).to.have.status(201);
                expect(res.body).to.be.a('object');
                expect(res.body).to.have.property('id');
                expect(res.body).to.have.property('title');
                expect(res.body).to.have.property('author');
                bookId = res.body.id;
                done();
            });
    });

    // Verify Getting All Books
    it('should GET all books', (done) => {
        chai.request(server)
            .get('/books')
            .end((err, res) => {
                expect(res).to.have.status(200);
                expect(res.body).to.be.a('array');
                done();
            });
    });

    // Verify Getting a Single Book
    it('should GET a single book', (done) => {
        chai.request(server)
            .get(`/books/${bookId}`)
            .end((err, res) => {
                expect(res).to.have.status(200);
                expect(res.body).to.be.a('object');
                expect(res.body).to.have.property('id');
                expect(res.body).to.have.property('title');
                expect(res.body).to.have.property('author');
                done();
            });
    });

    // Verify Updating a Book
    it('should PUT an existing book', (done) => {
        const bookid = 1;
        const updatedBook = { id: bookId, title: "Updated Test Book", author: "Updated Test Author" };

        chai.request(server)
            .put(`/books/${bookId}`)
            .send(updatedBook)
            .end((err, res) => {
                expect(res).to.have.status(200);
                expect(res.body).to.be.a('object');
                expect(res.body.title).to.be.equal('Updated Test Book');
                expect(res.body.author).to.be.equal('Updated Test Author');
                done();
            });
    });
    
    // Verify Deleting a Book
    it('should DELETE an existing book', (done) => {
        chai.request(server)
            .delete(`/books/${bookId}`)
            .end((err, res) => {
                expect(res).to.have.status(204);
                expect(res.body).to.be.a('object');
                done();
            });
    });

    // Verify Non-Existing Book
    it('should return 404 when trying to GET, PUT or DELETE a non-existing book', (done) => {
        chai.request(server)
        .get(`/books/${bookId}`)
        .end((err, res) => {
            expect(res).to.have.status(404);
            done();
        });

        chai.request(server)
        .put(`/books/${bookId}`)
        .send({ id: 9999, title: "Non-existing book", author: "Non-existing author"})
        .end((err, res) => {
            expect(res).to.have.status(404);
            done();
        });

        chai.request(server)
        .delete(`/books/${bookId}`)
        .end((err, res) => {
            expect(res).to.have.status(404);
            done();
        });

        chai.request(server)
            .delete(`/books/${bookId}`)
            .end((err, res) => {
                expect(res).to.have.status(404);
                done();
            });
    });
});