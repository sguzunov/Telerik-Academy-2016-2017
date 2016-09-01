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
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function() {
        var books = [];
        var categories = [];
        var lastId = 0;

        const bookTitleMinLength = 2,
            bookTitleMaxLength = 100,
            bookCategoryMaxLength = 100,
            bookCategoryMinLength = 2;

        // Validation
        function isStringLengthInRange(value, min, max) {
            var inRange = (min <= value.length) && (value.length <= max);
            return inRange;
        }

        function isValidIsbn(value) {
            if (value.length !== 10 && value.length !== 13) {
                return false;
            }

            let isValid = true;
            [].forEach.call(value, ch => {
                let toNumber = +ch;
                if (isNaN(toNumber)) {
                    isValid = false;
                }
            });

            return isValid;
        }

        function hasBookAlreadyBeenAdded(addedBook) {
            let hasBook = false;
            books.forEach(book => {
                if (book.title === addedBook.title || book.isbn === addedBook.isbn) {
                    hasBook = true;
                }
            });

            return hasBook;
        }

        function addCategory(categoryToAdd) {
            let hasCategory = false;
            categories.forEach(category => {
                if (category === categoryToAdd) {
                    hasCategory = true;
                }
            });

            if (!hasCategory) {
                categories.push(categoryToAdd);
            }
        }

        function listBooks(condition) {
            if (!condition) {
                return books.sort((a, b) => a.ID - b.ID);
            }

            let filterKey = Object.keys(condition)[0];
            return books.filter(book => book[filterKey] === condition[filterKey]).sort((a, b) => a.ID - b.ID);
        }

        function addBook(book) {
            if (typeof book === 'undefined') {
                throw new Error('Book cannot be undefined!');
            }

            if (!isStringLengthInRange(book.title, bookTitleMinLength, bookTitleMaxLength)) {
                throw new Error(`Book title length must be in range [${bookTitleMinLength}, ${bookTitleMaxLength}]!`);
            }

            if (!isStringLengthInRange(book.category, bookCategoryMinLength, bookCategoryMaxLength)) {
                throw new Error(`Book title length must be in range [${bookCategoryMinLength}, ${bookCategoryMaxLength}]!`);
            }

            if (!isValidIsbn(book.isbn)) {
                throw new Error(`Book ISBN is not valid!`);
            }

            if (book.author === '') {
                throw new Error(`Book author cannot be empty string!`);
            }

            addCategory(book.category);

            if (hasBookAlreadyBeenAdded(book)) {
                throw new Error(`Book with title: ${book.title} and isbn: ${book.isbn} has already been added!`);
            }

            book.ID = (lastId += 1);
            books.push(book);

            return book;
        }

        function listCategories() {
            return categories.slice(0);
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
    }());
    return library;
}

module.exports = solve;