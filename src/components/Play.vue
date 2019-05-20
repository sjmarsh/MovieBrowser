<template>
  <div>
    <h1>Play Movie</h1>
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
        title: null,
        moviePath: null,
        status: ''
      }
    },

    mounted() {
        this.moviePath = '/api/play/?title=' + this.title;
    }

  }

</script>