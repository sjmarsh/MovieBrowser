var app = new Vue({
    el: '#app',
    data() {
        return {
            title: null,
            moviePath: null,
            status: null
        }
    },
    mounted() {
        var params = new URLSearchParams(window.location.search);
        this.title = params.get('title');
        this.moviePath = '/api/play/?title=' + this.title;
    }
})