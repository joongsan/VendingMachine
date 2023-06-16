import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import Vuetify from "vuetify";
import 'vuetify/dist/vuetify.css';


Vue.config.productionTip = false;
Vue.use(Vuetify)

new Vue({
  router,
  store,
  vuetify: new Vuetify(),
  render: (h) => h(App),
}).$mount("#app");
