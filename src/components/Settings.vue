<template>
  <div class="container-fluid">
    <h1 class="t-header">Settings</h1>  
    <div class="home-button">
      <router-link :to="{ name: 'home'}" data-toggle="tooltip" data-placement="bottom" title="Home">
          <i class="material-icons md-48">home</i>
      </router-link>
    </div> 
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
      <div class="settings">
        <div class="form-group"> 
          <label for="movieFolderPath">Movie Folder Path:</label>
          <input id="movieFolderPath" type="text" class="form-control settings-text-input" v-model="settings.moviesFolderPath" />  
        </div>  
        <button v-on:click="saveSettings" class="btn btn-primary btn-save-settings">Save</button>
      </div>
    </div>
  </div>
</template>

<script>
  
  import Axios from 'axios';

  export default {
    data() {
      return {
        settings: { 
          moviesFolderPath: ''
        },
        status: null,
        loading: true
      }
    },
    mounted(){
      Axios.get('/api/settings')
        .then(response => {
          this.settings = response.data;
        })
        .catch(error => {
          this.status = 'Unexpected error occurred while retrieving Settings';
          console.log(error);
        })
        .finally(
          () => this.loading = false
        );
    },
    methods: {
        saveSettings: function() {
          this.loading = true;
          Axios.post('/api/settings', this.settings)
          .then(response => {
            this.status = 'Saved: ' + response.data;
          })
          .catch(error => {
            this.status = 'Unexpected error occurred while saving Settings';
            console.log(error);
          })
          .finally(
            () => this.loading = false
          );
        }
    }
  }

</script>