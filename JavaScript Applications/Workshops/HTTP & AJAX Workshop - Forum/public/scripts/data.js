var data = (function() {
    const USERNAME_STORAGE_KEY = 'username-key';

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user);
        return Promise.resolve(user);
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY)
        return Promise.resolve();
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
    }
    // end users

    // start threads
    function threadsGet() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads')
                .done(resolve)
                .fail(reject);
        });
    }

    function threadsAdd(title) {
        let endPointUrl = 'api/threads';

        return new Promise((resolve, reject) => {
            userGetCurrent()
                .then((user) => {
                    $.ajax({
                        method: 'POST',
                        url: endPointUrl,
                        contentType: 'application/json',
                        data: JSON.stringify({ title: title }),
                        success: resolve,
                        error: reject
                    });
                });
        });
    }

    function threadById(id) {
        id = +id;
        if (isNaN(id)) {
            throw new Error('ID must be a number!');
        }

        let endPointUrl = `api/threads/${id}`;
        return new Promise((resolve, reject) => {
            $.ajax({
                method: 'GET',
                url: endPointUrl,
                success: resolve,
                error: reject
            });
        });
    }

    function threadsAddMessage(threadId, content) {
        threadId = +threadId;
        if (isNaN(threadId)) {
            throw new Error('Thread ID must be a number!');
        }

        let endPointUrl = `api/threads/${threadId}/messages`;

        return new Promise((resolve, reject) => {
            $.ajax({
                method: 'POST',
                url: endPointUrl,
                contentType: 'application/json',
                data: JSON.stringify({})
            });
        });
    }
    // end threads

    // start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

    }
    // end gallery

    return {
        users: {
            login: userLogin,
            logout: userLogout,
            current: userGetCurrent
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            getById: threadById,
            addMessage: threadsAddMessage
        },
        gallery: {
            get: galleryGet,
        }
    }
})();