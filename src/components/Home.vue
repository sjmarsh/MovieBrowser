<template>
  <div class="container-fluid">
    <h1 class="t-header">Movies</h1>   
    <div class="settings-button">
      <router-link :to="{ name: 'settings'}" data-toggle="tooltip" data-placement="bottom" title="Settings">
          <i class="material-icons md-48">settings</i>
      </router-link>
    </div>
    <div v-if="loading">
        <progress-indicator/>
    </div>
    <div v-else>
      <div class="container-fluid t-movie-list">
          <div class="row">
            <div v-for="movie in movies" v-bind:key="movie.title" class="movie-thumbnail hovereffect col-md-2 col-sm-6 col-xs-6 ">
                <img :src="movie.coverArt" :alt="movie.title" class="img-responsive" />
                <div class="overlay">
                    <h2>{{movie.title}}</h2>
                    <router-link :to="{ name: 'detail', params: { title: movie.title }}" class="info" data-toggle="tooltip" data-placement="bottom" title="Movie Details">
                      <i class="material-icons md-36">info</i>
                    </router-link>
                    <router-link :to="{ name: 'play', params: { title: movie.title }}" class="info" data-toggle="tooltip" data-placement="bottom" title="Play Movie">
                        <i class="material-icons md-36">play_circle_outline</i>
                    </router-link>                              
                </div>
            </div>  
          </div>
          <div class="row">
              <div v-if="prevPages">
                <div class="arrow-up" v-on:click="getMovies('prev')"/>
              </div>
              <div v-if="morePages">
                <div class="arrow-down" v-on:click="getMovies('next')"/>
              </div>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Axios from 'axios';
  
  const pageSize = 10;
  
  export default {
    data() {
        return {
            movies: null,
            currentPage: 0,
            totalPages: 0,
            morePages: false,
            prevPages: false,
            loading: true,
            status: null
        };
    },
    mounted() {
        Axios
          .get('/api/movie', {params: {skip: 0, take: pageSize}})
          .then(response => {
            this.movies = response.data.movies;            
            if(response.data.movies.length > 0){
                this.currentPage = 1;
                this.totalPages = response.data.totalPages;
                this.morePages = response.data.totalPages > 1;
                this.$noty.success('Movies loaded');
            } else {
              this.$noty.warn('No Movies. Check the settings to change the movie location.');
              
            }
          })
          .catch(error => {
              this.$noty.error('Unexpected error occurred while retrieving Movies');
              console.log(error);
          })
          .finally(
              () => this.loading = false
          );
    },
    methods:{
      getMovies: function(direction){
        this.loading = true;
        if(direction == 'next'){
            this.currentPage += 1;
        }
        else{
            this.currentPage -= 1;
        }

        Axios
          .get('/api/movie', {params: {skip: (this.currentPage - 1) * pageSize, take: pageSize}})
          .then(response => {
            this.movies = response.data.movies;
            this.$noty.success('Movies loaded');
            this.totalPages = response.data.totalPages;
            this.morePages = this.currentPage < response.data.totalPages;
            this.prevPages = this.currentPage > 1;
          })
          .catch(error => {
              this.$noty.error('Unexpected error occurred while retrieving Movies');
              console.log(error);
          })
          .finally(
              () => this.loading = false
          );
      }
    }

  }

</script>
