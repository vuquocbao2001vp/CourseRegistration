<template>
  <div v-if="toastMessage" class="toast-container flex">
    <div class="toast-message flex">
      <div class="toast-icon flex"><div class="icon-toast-success"></div></div>
      <div class="toast-text">{{ toastMessage }}</div>
    </div>
  </div>
</template>
<script>
import { mapGetters } from "vuex";

export default {
  computed: {
    ...mapGetters(["toastMessage"]),
  },
};
</script>
<style scoped>
.toast-container {
  z-index: 300;
  position: absolute;
  top: 16px;
  left: 0;
  width: 100%;
  justify-content: center;
}
.toast-message {
  height: 40px;
  border-radius: 4px;
  border: 1px solid var(--input-normal-border-color);
  box-sizing: border-box;
  background-color: var(--primary-bg);
  padding: 0 8px;
}

.toast-icon {
  width: 28px;
  height: 28px;
  border-radius: 50%;
  background-color: var(--primary);
  justify-content: center;
}

.toast-text {
  margin-left: 8px;
  width: max-content;
  font-size: 16px;
}
</style>