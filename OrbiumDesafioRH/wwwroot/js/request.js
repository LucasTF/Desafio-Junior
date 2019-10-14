class Request {
    constructor() {
        this.http = new XMLHttpRequest();
    }
    get(url, callback) {
        this.http.open('GET', url, true);
        this.http.onload = () => {
            if (this.http.status === 200) {
                callback(null, this.http.responseText);
            }
            else{
                callback(this.http.status);
            }
        };
        this.http.send();
    }
    post(url, data, callback) {
        this.http.open('POST', url, true);
        this.http.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        this.http.onload = () => {
            callback(null, this.http.responseText);
        };
        this.http.send(JSON.stringify(data));
    }
    put(url, data, callback) {
        this.http.open('PUT', url, true);
        this.http.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        this.http.onload = () => {
            callback(null, this.http.responseText);
        };
        this.http.send(JSON.stringify(data));
    }
    delete(url, callback) {
        this.http.open('DELETE', url, true);
        this.http.onload = () => {
            if (this.http.status === 200) {
                callback(null, this.http.responseText);
            }
            else{
                callback(this.http.status);
            }
        };
        this.http.send();
    }
}

