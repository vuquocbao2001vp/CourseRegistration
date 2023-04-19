<template>
    <table>
      <thead>
        <slot name="table-header" />
      </thead>
      <tbody>
        <slot name="table-body" />
      </tbody>
    </table>

</template>

<script>
export default {};
</script>

<style>
table {
  width: 100%;
  border-spacing: 0;
  border-collapse: collapse;
  box-sizing: border-box;
}

table thead th {
  position: sticky;
  top: 0;
  height: 34px;
  background-color: #f4f5f8;
  width: 100%;
  box-sizing: border-box;
  font-weight: bold;
  z-index: 2;
}

table tbody tr {
  height: 36px;
  box-sizing: border-box;
}
table tr,
td {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}
.table-row-selected {
  background-color: #e5f3ff !important;
}
table tr td,
th {
  border: 1px solid #ccc;
  padding: 0 16px;
}
.td-text-left {
  text-align: left;
}
.td-text-center {
  text-align: center;
}
.td-text-right {
  text-align: right;
}
.row-selected {
  background-color: #E5F3FF !important;
}
.row-disabled {
  background-color: #f0f2e0 !important;
}
</style>