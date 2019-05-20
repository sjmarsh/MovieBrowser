import Vue from 'vue';
import VueRouter from 'vue-router';

import App from './App.vue';
import Home from './components/Home.vue';
import Detail from './components/Detail.vue';
import Play from './components/Play.vue';

Vue.use(VueRouter);

const router = new VueRouter({
  routes: [
    { path: '/', redirect: 'home' },
    { path: '/home', name: 'home', component: Home, props: false },
    { path: '/detail', name: 'detail', component: Detail, props: true },
    { path: '/play', name: 'play', component: Play, props: true }
  ]
});

new Vue({
  router,
  el: '#app',
  components: {'App': 'App', 'home': 'home'},
  render: h => h(App)
});
