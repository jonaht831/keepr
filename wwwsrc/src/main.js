// @ts-ignore
import Vue from 'vue'
// @ts-ignore
import App from './App.vue'
import router from './router'
import store from './store'

Vue.config.productionTip = false

new Vue({
  router,
  mounted() {
    //checks for valid session
    this.$store.dispatch("authenticate");
  },
  store,
  render: h => h(App)
}).$mount('#app')
