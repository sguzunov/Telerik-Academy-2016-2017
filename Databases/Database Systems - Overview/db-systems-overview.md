#### 1. What database models do you know?
Four database models:
* Hierarchical (tree)
* Network/ graph
* Object-oriented
* Relational

#### 2. Which are the main functions performed by a Relational Database Management System (RDBMS)?
RDBMS are popular as database servers. They support SQL language, mostly used for executing operations over them.
RDBMS implement creating, altering and modifying tables and the relations between them.

#### 3. Define what is "table" in database terms.
A table in RDBMS are the way engines store data. They consist of data. Each table have rows and columns.
Rows have the same structure. Table have a schema which defines the type and other rules of a column.

#### 4. Explain the difference between a primary and a foreign key.
Primary key is a column that identifies a row as unique. A foreign key is a column that has an identifier
that of a record stored in other table.

#### 5. Explain the different kinds of relationships between tables in relational databases.
There are three main relationships between tables:
* one-to-many (many-to-one) - a single record of a table has many records in another table.
* many-to-many - a single record in a table has many records in another table and vice versa.
* one-to-one - a single record of a table has only one record in another table.

#### 6. When is a certain database schema normalized? What are the advantages of normalized databases?
A database schema is normalized when repeating records are removed.
Advantages:
* No repeating data
* Database is consistent
* Using less storage space
* No way to insert wrong data format if a record is already inserted

#### 7. What are database integrity constraints and when are they used?
Database constraints ensure the data rules that cannot be violated.
* Primary key - Used to insure each data row to be unique in a table.
* Foreign key - Used to insure a value in a column is a record in another table.
* Unique key - Used to insure no repeating values in a column.
* Check constraint - Used to say that a column value meets some conditions.

#### 8. Point out the pros and cons of using indexes in a database.
Indexes are usually implemented as B-trees. It means that searching for a value is performed
with O(log n) logarithmic time. Indexes are a fast way for searching. Inserting or deleting a value
should be performed with re-balancing the tree. This already is slow operation.

#### 9. What's the main purpose of the SQL language?
SQL is a language for operating with RDBMS systems. It is separate on two parts: DDL and DML.
DDL is that part of the languages that allows to perform creating, deleting, dropping.
DML is the part that allows adding, deleting, inserting, updating data in the database.

#### 10. What are transactions used for? Give an example.
Transactions are a set of db operations that should be executed as a single unit.
Transactions ensure integrity and consistency of databases. If an operation fail in the transactions,
the changes should not be send to the database server.<br/>
**Example:** Money transfer from one account to another. If the source of money is empty the transaction should fail
and the operation should be cancelled.

#### 11. What is a NoSQL database?
Database which is schema free model. Data is stored in documents, e.g. JSON.
Data consistency is not ensured. Have CRUD operations and indexes.

#### 12. Explain the classical non-relational data models.
* Document model - set of documents - JSON objects.
* Key-value model - Set of key-value pairs.
* Hierarchical key-value - Set of key-value pairs.
* Wide-column model - Key-value model with schema.
* Object model - OOP style models.

#### 13. Give few examples of NoSQL databases and their pros and cons.
* MongoDB - It is flexible, there is no schema. Easy to scale. Data size is higher. It is less flexible with querying.
* Redis - Ultra fast in-memory. It is not persistent.
