<template>
  <div class="b-content">
    <base-loader />
    <router-view></router-view>
  </div>
</template>

<script>
</script>
<style scoped>
.b-content {
  background-color: #fff;
  width: calc(100% - 220px);
  height: 100%;
  box-sizing: border-box;
  padding: 0 20px 0 20px;
}
</style>
