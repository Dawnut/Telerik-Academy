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
	var library = (function () {
		var books = [];
		var categories = [];
		var idCounter = 1;

		function compare(a, b) {
			if (a.ID < b.ID)
				return -1;
			if (a.ID > b.ID)
				return 1;
			return 0;
		}

		function listBooks(term = null) {
			var sortedBooks = [];


			if (term === null) {
				sortedBooks = books.sort(compare);
			}
			else if (term.category !== null) {
				sortedBooks = books.filter(element => element.category === term.category).sort(compare);
			}
			else if (term.author !== null) {
				sortedBooks = books.filter(element => element.author === term.author).sort(compare);
			}

			return sortedBooks;

		}

		function addBook(book) {
			var newCategory = {};
			var categoryExists = false;
			validateBook(book);
			book.ID = idCounter;
			idCounter++;
			books.push(book);

			if (categories.length === 0) {
				newCategory.ID = idCounter;
				idCounter++;
				newCategory.name = book.category;
				categories.push(newCategory);
			}
			if (categories.length !== 0) {
				categories.forEach(element => {
					if (element.name === book.category) {
						categoryExists = true;
					}
				});
			}

			if (!categoryExists) {
				newCategory.ID = idCounter;
				idCounter++;
				newCategory.name = book.category;
				categories.push(newCategory);
			}

			return book;
		}

		function listCategories() {
			console.log(categories.sort(compare).map(x => x.name));
			return categories.sort(compare).map(x => x.name);
		}

		function validateBook(book) {

			if (book.title.length < 2) {
				throw new Error('Title too short');
			}
			else if (book.title.length > 100) {
				throw new Error('Title too long');
			}
			else if (book.isbn.length < 10 || book.isbn.length > 13) {
				throw new Error('ISBN code is invalid');
			}
			else if (typeof book.author != 'string') {
				throw new Error('Author is invalid');
			}
			else if (book.author === '') {
				throw new Error('Author is invalid');
			}
			books.forEach(element => {
				if (element.title === book.title) {
					throw new Error('Title already exists');
				}
				if (element.isbn === book.isbn) {
					throw new Error('Title already exists');
				}
			});
			return;
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

	// library.books.add({
	// 	"author": "John Doe",
	// 	"category": 'test',
	// 	"isbn": "1234567890123",
	// 	"title": "BOOK 1"
	// });
	// library.books.add({
	// 	"author": "John Doe",
	// 	"category": 'test2',
	// 	"isbn": "1345678290123",
	// 	"title": "BOOK 2"
	// });

	// library.books.add({
	// 	"author": "John Doe",
	// 	"category": 'test3',
	// 	"isbn": "1342678290123",
	// 	"title": "BOOK 3"
	// });
	// library.categories.list();

	return library;
}
// solve();

module.exports = solve;