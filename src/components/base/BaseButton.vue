<template>
  <div class="m-button m-button-blue flex" v-if="buttonType == 'regular'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
  <div class="m-button m-button-grey flex" v-if="buttonType == 'grey'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
  <div class="m-button m-button-white flex" v-if="buttonType == 'white'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
  <div class="m-button m-button-red flex" v-if="buttonType == 'red'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
  <div class="m-button m-button-square m-button-blue-square flex" v-if="buttonType == 'regular-square'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
  <div class="m-button m-button-square m-button-white-square flex" v-if="buttonType == 'white-square'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
  <div class="m-button m-button-square m-button-white m-button-white-regular-square flex" v-if="buttonType == 'white-regular-square'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
  <div class="m-button m-button-square m-button-red flex" v-if="buttonType == 'red-square'">
    <slot name="left" />
    <span>{{buttonName}}</span>
    <slot name="right" />
  </div>
</template>

<script>
export default {
    props: ['buttonType','buttonName']
}
</script>

<style scoped>
.m-button {
    min-width: 80px;
    min-height: 36px;
    border: 1px solid var(--button-primary-normal-border-color);
    border-radius: 99px;
    background-color: var(--button-primary-normal-bg-color);
    box-sizing: border-box;
    padding: 0 16px 0 12px;
    color: var(--text-white-primary-color);
    cursor: pointer;
    font-family: Verdana, Geneva, Tahoma, sans-serif !important;
    font-size: 16px;
    height: 100%;
    width: 100%;
    justify-content: center;
}
.m-button-blue:hover {
  background-color: var(--button-primary-hover-bg-color);
  border-color: var(--button-primary-hover-border-color);
  color: var(--text-white-secondary-color);
}

.m-button-grey {
  border: none;
  background-color: var(--button-primary-grey-bg-color);
}
.m-button-grey:hover {
  background-color: var(--button-primary-grey-hover-color);
}

.m-button-white {
  border-color: #e0e5e6;
  background-color: #f7f7f7;
  color: var(--text-primary-color);
  margin-left: 0px;
}
.m-button-white:hover {
  background-color: var(--primary-bg);
}
.m-button-red {
  border-color: rgb(255, 153, 0);
  background-color: rgb(255, 255, 255);
  color: rgb(255, 99, 51);
}
.m-button-red:hover {
  background-color: rgb(255, 255, 255);
    color: rgb(255, 153, 0);
    border: 1px solid rgb(255, 153, 0);
}
.m-button-square {
  border-radius: 2px;
}
.m-button-blue-square:hover {
  background-color: var(--button-primary-hover-bg-color);
  border-color: var(--button-primary-hover-border-color);
  color: var(--text-white-secondary-color);
}

.m-button-white-square {
  background-color: #fff;
  color: var(--text-blue-color);
  margin-left: 0px;
  border: 2px solid var(--button-primary-hover-bg-color);
}
.m-button-white-square:hover {
  background-color: var(--primary-bg);
}
</style>