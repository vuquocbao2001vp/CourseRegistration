<template>
  <div class="b-navbar">
    <div class="b-list-navbar">
      <ul>
        <li v-for="item in navbars" :key="item">
          <router-link :to="item.routerLink" class="navbar-item">
            <div class="icon-center"><div class="icon-list-navbar" :class="item.icon"></div></div>
            <span class="navbar-item-title">{{item.title}}</span>
          </router-link>
        </li>
      </ul>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      navbars: [
        {
          routerLink: "/home",
          title: "Trang chủ",
          icon: "icon-dashboard",
        },
        {
          routerLink: "/transcript",
          title: "Kết quả học tập",
          icon: "icon-report",
        },
        {
          routerLink: "/registration",
          title: "Đăng ký học",
          icon: "icon-tool",
        },
        {
          routerLink: "/registration_result",
          title: "Kết quả đăng ký học",
          icon: "icon-document",
        },
      ],
    };
  },
};
</script>
<style scoped>
.b-navbar{
    display: flex;
    flex-direction: column;
    background-color: var(--background-main);
    width:220px ;
    height: 100vh;
    padding: 14px 8px;
}

.b-list-navbar{
    flex-grow: 2;
}

.b-list-navbar ul{
    padding: 0;
    margin: 0;
    display: flex;
    flex-direction: column;
}
.b-list-navbar ul li{
    border-radius: 8px;
    list-style: none;
}
.b-list-navbar ul li  a{
    text-decoration: none;
    color: #000;
    width: 220px;
    height: 48px;
    margin-bottom: 4px;
}
.b-list-navbar li{
    height: 48px;
    display: flex;
    align-items: center;
    box-sizing: border-box;
    font-size: 15px;
}
.navbar-item{
    display: flex;
    padding-left: 16px;
    align-items: center;
    border-radius: 8px;
}

.b-list-navbar li:hover{
    background-color: #fff;
}

.router-link-active{
    font-family: Font Bold;
}
.router-link-active.navbar-item {
    background-color: #fff;
}

/* list icon navbar */
.icon-center {
    cursor: pointer;
    width: 24px;
    height: 24px;
    display: flex;
    align-items: center;
    justify-content: center;
    box-sizing: border-box;
    margin-right: 8px;
}
.icon-list-navbar{
    background: url('../../assets/img/Sprites.64af8f61.svg') no-repeat;
}
.icon-dashboard{
    background-position: -33px -1630px;
	width: 18px;
	height: 20px;
}
.icon-document{
    background-position: -254px -1632px;
	width: 14px;
	height: 17px;
}
.icon-tool{
    background-position: -339px -1633px;
	width: 18px;
	height: 17px;
}
.icon-report{
    background-position: -552px -1636px;
	width: 14px;
	height: 13px;
}

/* icon hover, active */
.router-link-active .icon-dashboard{
    mask: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -33px -1630px !important;
    background-color: #000000 !important;
    width: 18px;
	height: 20px;
}
.router-link-active .icon-document{
    mask: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -254px -1589px !important;
    background-color: #000 !important;
    width: 14px;
	height: 17px;
}
.router-link-active .icon-tool{
    mask: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -339px -1590px !important;
    background-color: #000 !important;
    width: 18px;
	height: 17px;
}
.router-link-active .icon-report{
    mask: url('../../assets/img/Sprites.64af8f61.svg') no-repeat -552px -1593px !important;
    background-color: #000 !important;
    width: 14px;
	height: 13px;
}


</style>