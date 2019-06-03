<template>
  <div>
    <h2>Movie Details</h2>
    <div class="container-fluid">
        <div v-if="loading">
           <div class="loader-wrapper">
            <div class="loader">
                <div class="loader__bar"></div>
                <div class="loader__bar"></div>
                <div class="loader__bar"></div>
                <div class="loader__bar"></div>
                <div class="loader__bar"></div>
                <div class="loader__ball"></div>
            </div>
          </div>
        </div>
        <div v-else>
            <div class="container t-movie-detail">
                <div class="row">
                    <div class="col-4">
                        Title
                    </div>
                    <div class="col-8">
                        {{movieDetail.localTitle}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        Production Year
                    </div>
                    <div class="col-8">
                        {{movieDetail.productionYear}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        Rating
                    </div>
                    <div class="col-8">
                        {{movieDetail.contentRating}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        Running Time
                    </div>
                    <div class="col-8">
                        {{movieDetail.runningTime}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        Overview
                    </div>
                    <div class="col-8">
                        {{movieDetail.overview}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        Genres
                    </div>
                    <div class="col-8">
                        {{movieDetail.genres}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        Actors
                    </div>
                    <div class="col-8">
                        {{movieDetail.actors}}
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        Cover
                    </div>
                    <div class="col-8">

                        <img :src="movieDetail.coverArt" alt="Base64 encoded image" height="200px" width="140px" />
                    </div>
                </div>
            </div>
        </div>

        <!--TODO: replace with toaster-->
        <h4>Status</h4>
        {{status}}
    </div>
  </div>
</template>

<script>
  import Axios from 'axios';
 
  export default {

    name: 'Detail',

    props: {
      title: {
        type: String,
        required: true
      }
    },

    data() {
      return {
        movieDetail: {},
        loading: true,
        status: ''
      }
    },

    mounted(){
      Axios
        .get('/api/movieDetail/?title=' + this.title)
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
        );
    }
  }
</script>