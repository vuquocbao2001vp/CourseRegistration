<template>
  <div v-if="loading == true" class="lds-ring"><div></div><div></div><div></div><div></div></div>
</template>

<script>
import {mapGetters} from 'vuex'
export default {
    computed: {
        ...mapGetters(["loading"])
    },
}
</script>

<style scoped>
.lds-ring {
  display: inline-block;
  position: absolute;
  top: 40%;
  left: calc(50% - 20px);
  width: 40px;
  height: 40px;
  z-index: 1000;
}
.lds-ring div {
  box-sizing: border-box;
  display: block;
  position: absolute;
  width: 40px;
  height: 40px;
  margin: 8px;
  border: 3px solid #fff;
  border-radius: 50%;
  animation: lds-ring 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
  border-color: var(--primary) transparent transparent transparent;
}
.lds-ring div:nth-child(1) {
  animation-delay: -0.45s;
}
.lds-ring div:nth-child(2) {
  animation-delay: -0.3s;
}
.lds-ring div:nth-child(3) {
  animation-delay: -0.15s;
}
@keyframes lds-ring {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}

</style>