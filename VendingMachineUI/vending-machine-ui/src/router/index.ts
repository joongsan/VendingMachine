import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Dashboard from "../views/Dashboard.vue";

Vue.use(VueRouter);

// Define the routes for the Vue Router
const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "dashboard",
    component: Dashboard,
  }
];

// Create a new VueRouter instance
const router = new VueRouter({
  routes,
});

export default router;
