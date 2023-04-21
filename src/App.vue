<template>
  <div v-if="isLoginRouter">
    <LoginPage />
  </div>
  <div v-if="!isLoginRouter" class="container-dashboard">
    <TheHeader />
    <div class="main-dashboard">
      <TheNavbar />
      <TheContent />
    </div>
  </div>
</template>

<script>
import {mapGetters, mapMutations, mapActions} from 'vuex'
import TheNavbar from "./components/layout/TheNavbar.vue";
import TheHeader from "./components/layout/TheHeader.vue";
import TheContent from "./components/layout/TheContent.vue";
import LoginPage from "@/pages/LoginPage.vue";
export default {
  name: "App",
  components: {
    TheNavbar,
    TheHeader,
    TheContent,
    LoginPage,
  },
  data() {
    return {
      isLoginRouter: true,
    }
  },
  computed: {
    ...mapGetters(["token"]),
  },  
  watch: {
    '$route.path': function(value){
      const parentRouter = value.split('/')[1];
      if(parentRouter == "login") this.isLoginRouter = true;
      else this.isLoginRouter = false;
    }
  },
  created(){
    const token = localStorage.getItem("key");
    const info = JSON.parse(localStorage.getItem("info"));
    if (token && info) {
      this.setToken(token);
    } else {
      this.logout();
    }
  },
  methods: {
    ...mapMutations(["setToken"]),
    ...mapActions(["logout"])
  },
};
</script>

<style>
@import url(./css/main.css);
.container-dashboard {
  width: 100%;
  height: 100vh;
  display: flex;
  flex-direction: column;
}
.main-dashboard {
  display: flex;
}
</style>
