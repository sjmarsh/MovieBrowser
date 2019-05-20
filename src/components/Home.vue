<template>
  <div class="container-fluid">
      <h1>Movies</h1>   
      <div v-if="loading">
          Loading...
      </div>
      <div v-else>
          <div class="container-fluid">
              <div class="row">
                  <div v-for="movie in movies" v-bind:key="movie" class="movie-thumbnail hovereffect col-md-2 col-sm-6 col-xs-6 ">
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
          </div>
      </div>

      <!--TODO: replace with toaster-->
      <h4>Status</h4>
      {{status}}
    </div>
</template>

<script>
  import Axios from 'axios';

  export default {
    data() {
        return {
            movies: null,
            loading: true,
            status: null
        };
    },
    mounted() {
        Axios
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
          );
    }
  }
</script>
