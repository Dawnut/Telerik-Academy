/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/category has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	let library = (function () {
		let books = [];
		let categories = [];
		let idCounter = 1;

		function listBooks(term = null) {
			return (term === null) ? books.sort(compareID) :
				(term.category) ? books.filter(element => element.category === term.category).sort(compareID) :
					(term.author) !== null ? books.filter(element => element.author === term.author).sort(compareID) : null
		}

		function addBook(book) {
			let newCategory = {};
			let categoryExists = false;

			validateBook(book);
			book.ID = idCounter;
			idCounter++;
			books.push(book);

			if (!categories) categoryExists = false
			else categories.forEach(element => {
				if (element.name === book.category) categoryExists = true;
			})

			if (!categoryExists) {
				categories.push({name: book.category, ID: idCounter});
				idCounter++;
			}
			return book; ``
		}

		function listCategories() {
			console.log(categories.sort(compareID).map(x => x.name));
			return categories.sort(compareID).map(x => x.name);
		}

		function compareID(a, b) {
			(a.ID < b.ID) ? -1 :
				(a.ID > b.ID) ? 1 : 0
		}

		function validateBook(book) {

			if (book.title.length < 2) throw new Error('Title too short');
			else if (book.title.length > 100) throw new Error('Title too long');
			else if (book.isbn.length < 10 || book.isbn.length > 13) throw new Error('ISBN code is invalid');
			else if (typeof book.author != 'string') throw new Error('Author is invalid');
			else if (book.author === '') throw new Error('Author is invalid');

			books.forEach(element => {
				if (element.title === book.title) throw new Error('Title already exists');
				if (element.isbn === book.isbn) throw new Error('Title already exists');
			});
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());

	return library;
}
module.exports = solve; //delete this for BGCoder