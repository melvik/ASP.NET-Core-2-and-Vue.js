<template>
    <div>
        <h1>Welcome to Hands on Vue.js with ASP.NET Core!-!</h1>
        <p>
            NOW The time is: {{ time }}
        </p>
         <p>
            The current users of our system are:
            <ul>
                <li 
                  v-for="user in users"
                  :key="user.userName">
                    {{user.fullName}} {{user.userName}}
                </li>
            </ul>
        </p>

        <product-list/>
    <router-view />

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