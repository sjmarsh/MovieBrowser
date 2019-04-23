﻿var app = new Vue({
    el: '#app',
    data() {
        return {
            movies: null,
            loading: true,
            status: null
        }
    },
    mounted() {
        axios
            .get('/api/movie')
            .then(response => {
                this.movies = response.data;
                this.status = 'Data loaded';
            })
            .catch(error => {
                this.status = 'Unexpected error occurred while retrieving Movies';
                console.log(error);
            })
            .finally(
                () => this.loading = false
            )
    }
})
