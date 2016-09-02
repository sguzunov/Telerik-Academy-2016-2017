/* globals console */

'use strict';

class listNode {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class LinkedList {
    constructor() {
        this._first = null;
        this._last = null;
        this._length = 0;
    }

    get first() {
        return this._first.value;
    }

    get last() {
        return this._last.value;
    }

    get length() {
        return this._length;
    }

    append(...args) {
        for (let i = 0, len = args.length; i < len; i += 1) {
            let node = new listNode(args[i]);
            if (0 === this._length) {
                this._first = node;
                this._last = node;
            } else {
                // If not set, first.next refers null
                if (this._length === 1) {
                    this._first.next = this._last;
                }

                this._last.next = node;
                this._last = node;
            }

            this._length += 1;
        }

        return this;
    }

    prepend(...args) {
        for (let i = args.length - 1; i >= 0; i -= 1) {
            let node = new listNode(args[i]);
            if (0 === this._length) {
                this._first = node;
                this._last = node;
            } else {
                node.next = this._first;
                this._first = node;
            }

            this._length += 1;
        }

        return this;
    }

    insert(indexToInsertAt, ...args) {
        this._validateIndexRange(indexToInsertAt);

        let { chainHeadNode, chainTailNode } = this._chainNodes(args);
        if (indexToInsertAt === 0) {
            chainTailNode.next = this._first;
            this._first = chainHeadNode;
        } else {
            let nodeBeforeIndex = this._findNodeBeforeIndex(indexToInsertAt);
            chainTailNode.next = nodeBeforeIndex.next;
            nodeBeforeIndex.next = chainHeadNode;
        }

        this._length += args.length;

        return this;
    }

    at(index, newValue) {
        this._validateIndexRange(index);

        let currentNode = this._first;
        let currentIndex = 0;
        while (currentNode.next && currentIndex < index) {
            currentNode = currentNode.next;
            currentIndex += 1;
        }

        if (typeof newValue === 'undefined') {
            return currentNode.value;
        } else {
            currentNode.value = newValue;
        }
    }

    removeAt(index) {
        this._validateIndexRange(index);

        let value;
        if (0 === index) {
            value = this._first.value;
            this._first = this._first.next;

            if (this._length === 1) {
                this._last = this._first;
            }
        } else {
            let nodeBeforeIndex = this._findNodeBeforeIndex(index);
            if (nodeBeforeIndex && (nodeBeforeIndex.next === this._last)) {
                value = nodeBeforeIndex.next.value;
                nodeBeforeIndex.next = null;
                this._last = nodeBeforeIndex;
            } else {
                value = nodeBeforeIndex.next.value;
                nodeBeforeIndex.next = nodeBeforeIndex.next.next;
            }
        }

        this._length -= 1;

        return value;
    }

    // Allows performing for...of loop.
    * [Symbol.iterator]() {
        let currentNode = this._first;
        while (currentNode) {
            yield currentNode.value;
            currentNode = currentNode.next;
        }
    }

    toArray() {
        let result = [];
        for (let element of this) {
            result.push(element);
        }

        return result;
    }

    toString() {
        let result = this.toArray().join(' -> ');
        return result;
    }

    _findNodeBeforeIndex(index) {
        let nodeBeforeIndex = this._first;
        let currentIndex = 0;

        // currentIndex < indexToInsertAt - 1 - because we need a reference to the node at index.
        while (nodeBeforeIndex && currentIndex < index - 1) {
            nodeBeforeIndex = nodeBeforeIndex.next;
            currentIndex += 1;
        }

        return nodeBeforeIndex;
    }

    _validateIndexRange(index) {
        if (!(0 <= index && index < this._length)) {
            throw new Error(`Index should be less than list\'s size of: ${this._length}!`);
        }
    }

    _chainNodes(args) {
        let chainHeadNode = new listNode(args[0]);
        let chainTailNode = chainHeadNode;
        for (let i = 1, len = args.length; i < len; i += 1) {
            chainTailNode.next = new listNode(args[i]);
            chainTailNode = chainTailNode.next;
        }

        return {
            chainHeadNode,
            chainTailNode
        }
    }
}

module.exports = LinkedList;