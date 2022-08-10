import axios from "axios"

export default {
    name: "ApiService",
    createUrl(url) {
        return "http://localhost:18234" + url;
    },
    onError(err) {
        console.log(err);
    },
    get(url) {
        return axios.get(this.createUrl(url))
            .catch(this.onError)
    },
    put(url, data) {
        return axios.put(this.createUrl(url), data)
            .catch(this.onError)
    },
    post(url, data) {
        return axios.post(this.createUrl(url), data)
            .catch(this.onError)
    },
    delete(url) {
        return axios.delete(this.createUrl(url))
            .catch(this.onError)
    }
}
