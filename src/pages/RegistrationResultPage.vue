<template>
  <div class="transcript-page">
    <div class="transcript-header flex">
      <div class="header-title font-semibold">KẾT QUẢ ĐĂNG KÝ HỌC</div>
      <div class="student-info flex">
        <div class="info-text font-semibold">Sinh viên: {{student.FullName}}</div>
        <div class="info-text font-semibold">Mã số: {{student.StudentCode}}</div>
        <div class="info-text font-semibold">Lớp: {{student.Class}}</div>
        <div class="info-text font-semibold">Học kì: HK1-2024</div>
      </div>
    </div>
    <div class="transcript-table">
      <base-table>
        <template #table-header>
          <tr>
            <th style="width: 40px">STT</th>
            <th class="td-text-left" style="width: 140px">Mã môn học</th>
            <th class="td-text-left" style="width: 200px">Tên môn học</th>
            <th style="width: 40px">Số tín chỉ</th>
            <th style="width: 120px">Trạng thái</th>
            <th style="width: 120px">Thứ</th>
            <th style="width: 120px">Tiết</th>
            <th style="width: 120px">Giảng đường</th>
          </tr>
        </template>
        <template #table-body>
          <tr v-for="(subject, index) in enrollment" :key="index">
            <td class="td-text-center">{{index + 1}}</td>
            <td>{{subject.CourseCode}}</td>
            <td>{{subject.CourseName}}</td>
            <td class="td-text-center">{{subject.Credit}}</td>
            <td class="td-text-center">{{regisStatus[subject.Status-1]}}</td>
            <td class="td-text-center">{{subject.Schedule.substring(0, 5)}}</td>
            <td class="td-text-center">{{subject.Schedule.substring(subject.Schedule.indexOf('(') + 1, subject.Schedule.indexOf(')')).replace('Tiết ', '')}}</td>
            <td class="td-text-center">{{subject.Amphitheater}}</td>
          </tr>
          <tr>
            <td></td>
            <td></td>
            <td class="td-text-center font-semibold">Tổng số</td>
            <td class="td-text-center">{{totalCredit}}</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
          </tr>
        </template>
      </base-table>
    </div>
  </div>
</template>

<script>
import BaseTable from '@/components/base/BaseTable.vue';
import {mapGetters, mapMutations, mapActions} from 'vuex'
export default {
  components: { BaseTable },
  data() {
    return {
      regisStatus: ['Đăng ký lần đầu', 'Học lại', 'Học cải thiện', 'Đăng ký tự do'],
    }
  },
  computed: {
    ...mapGetters(["enrollments", "student"]),
    enrollment(){
      if(this.enrollments) return this.enrollments.enrollment;
      else return [];
    },
    totalCredit(){
      if(this.enrollments) return this.enrollments.totalCredit;
      else return 0;
    },
  },
  created() {
    const info = JSON.parse(localStorage.getItem("info"));
    if (info) {
      this.setStudent(info);
      this.getEnrollments(info.StudentID)
    } else {
      this.setStudent({});
    }
  },
  methods: {
    ...mapMutations(["setEnrollments", "setStudent"]),
    ...mapActions(["getEnrollments"])
  },
};
</script>

<style scoped>
.transcript-page {
  padding: 24px 0;
}
.transcript-header {
  flex-direction: column;
}
.header-title {
  font-size: 24px;
}
.info-text {
  font-size: 16px;
  padding: 16px 40px;
}
.transcript-table{
  width: 100%;
  height: calc(100vh - 225px);
  overflow: auto;
  box-sizing: border-box;
}


tbody tr:hover {
  background-color: #fff;
}

</style>