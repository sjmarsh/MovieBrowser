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
        axios
            .get('/api/movieDetail')
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