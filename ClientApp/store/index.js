import Vue from "vue"
import Vuex from "vuex"
import * as actions from "./actions"
import * as mutations from "./mutations"
// import * as getters from "./getters"
Vue.use(Vuex)

store.subscribe((mutation, state) => {
  localStorage.setItem("store", JSON.stringify(state));
})

export default new Vuex.Store({
    state: {},
    //getters,
    actions,
    mutations,
    state: {
      cart: []
    }
  })
  