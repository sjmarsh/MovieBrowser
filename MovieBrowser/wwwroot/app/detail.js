var app = new Vue({
    el: '#app',
    data() {
        return {
            movieDetail: null,
            loading: true,
            status: null
        }
    },
    mounted() {
        var params = new URLSearchParams(window.location.search);
        var title = params.get('title');


        axios
            .get('/api/movieDetail/?title=' + title)
            .then(response => {
                this.movieDetail = response.data;
                if (response.data.coverArt) {
                    this.movieDetail.coverArt = 'data:image/jpg;base64,'.concat(response.data.coverArt);
                }
                this.status = 'Data loaded';
            })
            .catch(error => {
                this.status = 'Unexpected error occurred while retrieving Movie Details';
                console.log(error);
            })
            .finally(
                () => this.loading = false
            )
    }
})