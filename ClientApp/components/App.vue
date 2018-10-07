<template>
<div class="app">
    <b-navbar toggleable="md" type="dark" variant="dark">
      <b-container>
        <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
        <b-navbar-brand to="/">PhoneShop</b-navbar-brand>
        <b-collapse is-nav id="nav_collapse">
          <b-navbar-nav>
            <b-nav-item to="/products">Products</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-container>
    </b-navbar>

    <transition name="fade" mode="out-in">
    <router-view />
    </transition>
</div>
</template>

<script>
import ProductList from "./products/List.vue";
export default {
    name: 'app',
    data () {
        return {
            time: new Date().toString(),
            users: []
        }
    },
    created () {
            fetch('/api/users').then(response => {
                return response.json()
            })
            .then(data => {
                this.users = data
            });
    },
    components: {
        ProductList: ProductList
    }
}
</script>

<style lang="scss">
html,
body {
  height: 100vh;
}
div.app,
div.page {
  height: 100% !important;
}
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease-in-out;
}

.fade-enter,
.fade-leave-to {
  opacity: 0;
}
</style>