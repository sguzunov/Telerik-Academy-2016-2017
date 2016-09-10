'use strict';

function solve() {
    function isRepeatedId(id, array) {
        let occurs = 0;
        for (let value of array) {
            if (value.StudentID === id) {
                occurs += 1;
            }

            // When ID is met more than once no more checks needed.
            if (occurs > 1) {
                return true;
            }
        }

        return false;
    }

    function hasConsecutiveSpaces(value) {
        for (let i = 1; i < value.length; i += 1) {
            if (value[i - 1] === ' ' && value[i] === ' ') {
                return true;
            }
        }

        return false;
    }

    function validateId(id) {
        if (!(typeof id === 'number' || id instanceof Number)) {
            throw new Error('ID must be a number!');
        }

        if (id < 1) {
            throw new Error('ID must be bigger than 0!');
        }

        if ((id | 0) !== id) {
            throw new Error('ID must be a whole number!');
        }
    }

    function validateTitles(...args) {
        for (let title of args) {
            if (!isString(title)) {
                throw new Error('Title must be a string!');
            }

            if (title.length < 1) {
                throw new Error('Title\'s length must be bigger than 0!');
            }

            if (title[0] === ' ' || title[title.length - 1] === ' ') {
                throw new Error('Title should not start or end with white space!');
            }

            if (hasConsecutiveSpaces(title)) {
                throw new Error('Title should not have consecutive white spaces!');
            }
        }
    }

    function validateStudentName(name) {
        if (!isString(name)) {
            throw new Error('Name must be a string!');
        }

        if (name.length < 1) {
            throw new Error('Name\'s length must be bigger than 0!');
        }

        if (!(65 <= name.charCodeAt(0) && name.charCodeAt(0) <= 90)) {
            throw new Error('Name\'s first letter must be un upper case letter!');
        }

        for (let i = 1; i < name.length; i += 1) {
            if (!(97 <= name.charCodeAt(i) && name.charCodeAt(i) <= 122)) {
                throw new Error('Name\'s should contains only lower case letters except the first one!');
            }
        }
    }

    function isString(value) {
        return typeof value === 'string' || value instanceof String;
    }

    var Course = {
        init: function(title, presentations) {
            if (typeof presentations === 'undefined' || presentations.length === 0) {
                throw new Error("No presentations!");
            }

            validateTitles(title);
            validateTitles(...presentations);

            this._lastId = 0;
            this._title = title;
            this._presentations = presentations;
            this._students = [];
            this._homeworks = {};
            this._examResults = {};

            return this;
        },
        addStudent: function(name) {
            let nameTokens = name.split(' ');
            if (nameTokens.length !== 2) {
                throw new Error('Name format is not correct!');
            }

            let firstName = nameTokens[0];
            let lastName = nameTokens[1];
            validateStudentName(firstName);
            validateStudentName(lastName);

            this._lastId += 1;
            let newStudent = {
                id: this._lastId,
                firstName: firstName,
                lastName: lastName
            };

            this._students.push(newStudent);

            return this._lastId;
        },
        getAllStudents: function() {
            let result = this._students.map((student) => {
                return {
                    id: student.id,
                    firstname: student.firstName,
                    lastname: student.lastName
                };
            });
            return result;
        },
        submitHomework: function(studentID, homeworkID) {
            validateId(studentID);
            validateId(homeworkID);

            if (studentID > this._students.length) {
                throw new Error('Student id is out of range!');
            }

            if (homeworkID > this._presentations.length) {
                throw new Error('Invalid HW ID!');
            }

            let studentExists = false;
            this._students.forEach((student) => {
                if (student.id === studentID) {
                    studentExists = true;
                }
            });

            if (!studentExists) {
                throw new Error(`There is no student with ID = ${studentID}!`);
            }

            if (!this._homeworks.hasOwnProperty(studentID)) {
                this._homeworks[studentID] = [];
            }

            if (this._homeworks[studentID].indexOf(homeworkID) < -1) {
                this._homeworks.push(homeworkID);
            }

            return this;
        },
        pushExamResults: function(results) {
            if (!Array.isArray(results)) {
                throw new Error('The results must be passed as an array!');
            }

            for (let result of results) {
                let id = result.StudentID;
                validateId(id);

                if (id > this._students.length) {
                    throw new Error('Student id is out of range!');
                }

                if (isRepeatedId(id, results)) {
                    throw new Error(`Cheater id: ${result.StudentID}`);
                }

                if (isNaN(result.score)) {
                    throw new Error('Score must be a number!');
                }

                this._examResults[result.StudentID] = result.score;
            }

            return this;
        },
        getTopStudents: function() {
            let result = [];

            for (let student of this._students) {
                let id = student.id;
                let homeworkPercent = 0;
                if (this._homeworks.hasOwnProperty(id)) {
                    homeworkPercent = (this._homeworks[id] / this._presentations.length) * 0.25;
                }

                let examPercentage = 0;
                if (this._examResults.hasOwnProperty(id)) {
                    homeworkPercent = this._examResults[id] * 0.75;
                }

                result.push({
                    id: id,
                    firstname: student.firstName,
                    secondname: student.secondName,
                    score: examPercentage + homeworkPercent
                });
            }

            result = result.sort((x, y) => x.score - y.score);
            if (result.length > 10) {
                return result.slice(0, 10);
            } else {
                return result.slice(0);
            }
        }
    };

    return Course;
}

// let course = solve();

// // course.init('JS', ['Fund', 'Modules']);

// console.log('az'.charCodeAt(0));

module.exports = solve;