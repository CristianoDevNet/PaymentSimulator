import Vue from "vue";
import Router from "vue-router";

import PaymentSimulation from "./components/PaymentSimulation";
import SavedSimulations from "./components/SavedSimulations";
import About from "./components/About";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "Origin",
      component: PaymentSimulation
    },
    {
      path: "/PaymentSimulation",
      name: "PaymentSimulation",
      component: PaymentSimulation
    },
    {
      path: "/SavedSimulations",
      name: "SavedSimulations",
      component: SavedSimulations
    },
    {
      path: "/About",
      name: "About",
      component: About
    }
  ]
});