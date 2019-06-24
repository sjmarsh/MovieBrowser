import Vue from 'vue';
import VueRouter from 'vue-router';
import VueNoty from 'vuejs-noty';

import App from './App.vue';
import Home from './components/Home.vue';
import Detail from './components/Detail.vue';
import Play from './components/Play.vue';
import Settings from './components/Settings.vue';

import 'vuejs-noty/dist/vuejs-noty.css';

Vue.use(VueRouter);
Vue.use(VueNoty, {timeout: 3000, progressBar: false, layout: 'topRight'});

const router = new VueRouter({
  routes: [
    { path: '/', redirect: 'home' },
    { path: '/home', name: 'home', component: Home, props: false },
    { path: '/detail', name: 'detail', component: Detail, props: true },
    { path: '/play', name: 'play', component: Play, props: true },
    { path: '/settings', name: 'settings', component: Settings, props: false },
  ]
});

new Vue({
  router,
  el: '#app',
  components: {'App': 'App', 'home': 'home'},
  render: h => h(App)
});
