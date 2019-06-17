<template>
  <div>
    <h1>Play Movie</h1>
    <div class="home-button">
      <router-link :to="{ name: 'home'}" data-toggle="tooltip" data-placement="bottom" title="Home">
          <i class="material-icons md-48">home</i>
      </router-link>
    </div> 
    <video height="90%" width="90%" controls >
        <source :src="moviePath" type="video/mp4">
        Your browser does not support the video tag.
    </video>
  </div>
</template>

<script>

  export default {

    name: 'Play',

    props: {
      title: {
        type: String,
        required: true
      },
    },

    data() {
      return {
        moviePath: null,
        status: ''
      }
    },

    mounted() {
        this.moviePath = '/api/play/?title=' + this.title;
    }

  }

</script>