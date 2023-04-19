<template>
  <div class="b-popup flex">
    <div class="b-popup-main flex">
      <div class="b-popup-header">
        <div class="b-popup-header-title">
          <slot name="header"></slot>
        </div>
      </div>
      <div class="b-popup-content">
        <slot name="content"></slot>
      </div>
      <div class="b-popup-control">
        <slot name="control"></slot>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.b-popup {
  position: fixed;
  justify-content: center;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.4);
  z-index: 100;
}
.b-popup-main {
  position: relative;
  flex-direction: column;
  box-sizing: border-box;
  padding: 16px 32px;
  background-color: #fff;
  align-items: flex-start;
  width: max-content;
  max-height: 100%;
  overflow: auto;
}
.b-popup-header {
  position: relative;
  box-sizing: border-box;
  width: 100%;
}
.b-popup-header-title {
  font-size: 1.5rem;
  font-family: Font Bold;
  padding-bottom: 16px;
}
.b-popup-content {
  padding-bottom: 16px;
  width: 100%;
  box-sizing: border-box;
  position: relative;
}
.b-popup-control {
  padding-bottom: 16px;
  width: 100%;
  box-sizing: border-box;
  position: relative;
}
</style>