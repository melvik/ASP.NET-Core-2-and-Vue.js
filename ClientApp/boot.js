import Vue from 'vue'
import VueRouter from 'vue-router'
import BootstrapVue from "bootstrap-vue"
import NProgress from "nprogress";
import store from './store'
import Cart from "./pages/Cart.vue";
import VueToastr from"@deveodk/vue-toastr"
import "@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css"

Vue.use(VueRouter)
Vue.use(BootstrapVue)
Vue.use(VueToastr, {
  defaultPosition:"toast-top-right"
})
// filters
import { currency } from"./filters"
Vue.filter("currency", currency);

import Catalogue from "./pages/Catalogue.vue"
import Product from "./pages/Product.vue"

const routes = [
     { path: "/products", component: Catalogue },
     { path: "/products/:slug", component: Product },
     { path: "*", redirect: "/products" },
     { path: "/cart", component: Cart }
  ];

const router = new VueRouter({ mode: "history", routes: routes });

router.beforeEach((to, from, next) => {
  NProgress.start();
  next();
});

router.afterEach((to, from) => {
  NProgress.done();
});

new Vue({
    el: '#app-root',
    store,
    router: router,
    // router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/App.vue'))
});