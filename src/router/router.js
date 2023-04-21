import { createRouter, createWebHistory } from "vue-router";
import store from "@/store/store";

import HomePage from "../pages/HomePage.vue";
import TranscriptPage from "../pages/TranscriptPage.vue";
import RegistrationPage from "../pages/RegistrationPage.vue";
import RegistrationResultPage from "../pages/RegistrationResultPage.vue";
import LoginPage from "../pages/LoginPage.vue";

const _routes = [
  { path: "/", redirect: "/home"},
  { path: "/home", component: HomePage },
  { path: "/transcript", component: TranscriptPage },
  { path: "/registration", component: RegistrationPage },
  { path: "/registration_result", component: RegistrationResultPage },
  { path: "/login", component: LoginPage },

];
const router = createRouter({
  history: createWebHistory(),
  routes: _routes,
});

const token = localStorage.getItem("key")
const info = localStorage.getItem("info")
// Thêm navigation guard trước khi vào mỗi route
router.beforeEach((to, from, next) => {
  // Kiểm tra xem route tồn tại hay không
  const exists = router.getRoutes().some((route) => route.path === to.path);
  if (exists) {
    // Nếu tồn tại thì tiếp tục điều hướng
    next();
  } else {
    if (token !== null) {
      next("/home");
    } else {
      next("/login");
    }
  }
  // về login
  if (token !== null && info !== null && from.path == "/" && to.path == "/login") {
    if (confirm("Bạn có chắc chắn muốn đăng xuất không?")) {
      store.dispatch("userLogout");
    } else {
      router.go(-1);
    }
  }
});
export default router;