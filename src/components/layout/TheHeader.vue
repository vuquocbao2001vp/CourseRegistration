<template>
  <div class="header-dashboard flex">
    <div class="header-branch flex">
      <div class="logo-navbar"></div>
      <div class="logo-navbar-title">Trường Đại học Công nghệ</div>
    </div>
    <div class="flex-end-block flex">
      <span>{{ student.FullName }}</span>
      <div @click="expandAdmin" class="header-right-icon flex"><div class="icon-down"></div></div>
    </div>
    <div v-if="isExpandAdmin" @click="logoutOnClick" class="logout-panel flex">
      Đăng xuất
    </div>
  </div>
</template>
<script>
import { mapGetters, mapMutations, mapActions } from "vuex";
export default {
  data() {
    return {
      isExpandAdmin: false,
    };
  },
  computed: {
    ...mapGetters(["student"]),
  },
  created() {
    const info = JSON.parse(localStorage.getItem("info"));
    if (info) {
      this.setStudent(info);
    } else {
      this.setStudent({});
    }
  },
  methods: {
    ...mapMutations(["setStudent"]),
    ...mapActions(["logout"]),
    expandAdmin() {
      this.isExpandAdmin = !this.isExpandAdmin;
      if (this.isExpandAdmin == true) {
        setTimeout(() => {
          this.isExpandAdmin = false;
        }, 10000);
      }
    },
    logoutOnClick() {
      if (confirm("Bạn có chắc chắn muốn đăng xuất không?")) {
        this.logout();
      } else {
        this.isExpandAdmin = false;
      }
    },
  },
};
</script>
<style scoped>
.header-dashboard {
  width: 100%;
  min-height: 60px !important;
  background-color: #fff;
  box-shadow: 0 2px 4px rgba(208, 206, 206, 0.5);
  z-index: 100;
}
.header-branch {
  padding-left: 90px;
  box-sizing: border-box;
}
.logo-navbar {
  height: 56px;
  width: 56px;
  background-image: url(@/assets/img/logo_UET.webp);
  background-size: cover;
  box-sizing: border-box;
}
.logo-navbar-title {
  padding: 0 16px;
  font-size: 26px;
  font-family: Font Bold;
  color: rgb(53, 52, 52);
}
.icon-down {
  mask: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -1078px -38px;
  width: 9px;
  height: 6px;
  background-color: #fff;
}

.header-right-icon {
  margin-left: 8px;
  justify-content: center;
  width: 14px;
  height: 14px;
  cursor: pointer;
}

.flex-end-block {
  padding: 0 16px;
  height: 36px;
  position: absolute;
  right: 20px;
  top: 12px;
  font-family: Font SemiBold;
  font-size: 16px;
  background-color: var(--primary);
  border-radius: 4px;
  color: #fff;
}
.logout-panel {
  position: absolute;
  top: 48px;
  right: 20px;
  height: 36px;
  width: 136px;
  cursor: pointer;
  justify-content: center;
  border: 1px solid var(--input-normal-border-color);
  background-color: #f2f1f1;
  z-index: 100;
}
.logout-panel:hover{
  background-color: #fff;
}
</style>