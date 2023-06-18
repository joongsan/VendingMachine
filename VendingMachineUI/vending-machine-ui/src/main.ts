// Import the necessary dependencies
import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import Vuetify from "vuetify";
import 'vuetify/dist/vuetify.css';
import 'material-icons/iconfont/material-icons.css';
import '@mdi/font/css/materialdesignicons.css';

// Disable production tip in the console
Vue.config.productionTip = false;

// Use Vuetify for styling and UI components
Vue.use(Vuetify);

// Create a new Vue instance
new Vue({
  // Specify the router for navigation
  router,
  // Provide the store for managing application state
  store,
  // Create a new instance of Vuetify for styling
  vuetify: new Vuetify(),
  // Render the App component as the root component
  render: (h) => h(App),
}).$mount("#app");
