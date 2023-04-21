<template>
  <div id="transcript">
    <div class="transcript-page">
      <div class="transcript-header flex">
        <div class="header-title font-semibold">KẾT QUẢ HỌC TẬP</div>
        <div class="student-info flex">
          <div class="info-text font-semibold">
            Sinh viên: {{ student.FullName }}
          </div>
          <div class="info-text font-semibold">
            Mã số: {{ student.StudentCode }}
          </div>
          <div class="info-text font-semibold">Lớp: {{ student.Class }}</div>
        </div>
      </div>
      <div class="transcript-table">
        <table id="my-table">
          <thead>
            <tr>
              <th class="td-text-left" style="width: 40px">Học kì</th>
              <th style="width: 40px">STT</th>
              <th class="td-text-left" style="width: 140px">Mã môn học</th>
              <th class="td-text-left" style="width: 200px">Tên môn học</th>
              <th style="width: 120px">Số tín chỉ</th>
              <th style="width: 120px">Điểm</th>
            </tr>
          </thead>
          <tbody>
            <template v-for="(course, index) in transcript" :key="index">
              <tr>
                <td :rowspan="course.Grades.length">{{ course.Semester }}</td>
                <td class="td-text-center">1</td>
                <td>{{ course.Grades[0].CourseCode }}</td>
                <td>{{ course.Grades[0].CourseName }}</td>
                <td class="td-text-center">{{ course.Grades[0].Credit }}</td>
                <td class="td-text-center">{{ course.Grades[0].Score }}</td>
              </tr>
              <template
                v-for="(grade, gradeIndex) in course.Grades.slice(1)"
                :key="gradeIndex"
              >
                <tr>
                  <td class="td-text-center">{{ gradeIndex + 2 }}</td>
                  <td>{{ grade.CourseCode }}</td>
                  <td>{{ grade.CourseName }}</td>
                  <td class="td-text-center">{{ grade.Credit }}</td>
                  <td class="td-text-center">{{ grade.Score }}</td>
                </tr>
              </template>
            </template>
          </tbody>
        </table>
      </div>
      <div class="transcript-total">
        <div class="transcript-total-title">
          Tổng tín chỉ: {{ totalCredit }}
        </div>
        <div class="transcript-total-title">
          Số tín chỉ tích lũy: {{ accumulatedCredit }}
        </div>
        <div class="transcript-total-title">
          Điểm trung bình: {{ accumulatedScore }}
        </div>
      </div>
    </div>
  </div>
  <!-- <div class="export-button" @click="exportToPdf">
    <BaseButton buttonName="Xuất ra pdf" buttonType="white-square" />
  </div> -->
</template>

<script>
import { mapGetters, mapMutations, mapActions } from "vuex";

export default {
  computed: {
    ...mapGetters(["transcripts", "student"]),
    transcript() {
      if (this.transcripts) return this.transcripts.transcript;
      else return [];
    },
    totalCredit() {
      if (this.transcripts) return this.transcripts.totalCredit;
      else return 0;
    },
    accumulatedCredit() {
      if (this.transcripts) return this.transcripts.accumulatedCredit;
      else return 0;
    },
    accumulatedScore() {
      if (this.transcripts) return this.transcripts.accumulatedScore;
      else return 0;
    },
  },
  created() {
    const info = JSON.parse(localStorage.getItem("info"));
    if (info) {
      this.setStudent(info);
      this.getTranscipts(info.StudentID);
    } else {
      this.setStudent({});
    }
  },
  methods: {
    ...mapMutations(["setTranscripts", "setStudent"]),
    ...mapActions(["getTranscipts"]),
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
  padding: 16px 20px;
  white-space: nowrap;
}
.transcript-table {
  width: 100%;
  height: calc(100vh - 297px);
  overflow: auto;
  box-sizing: border-box;
  border-bottom: 1px solid #ccc;
}
.transcript-total {
  padding-top: 16px;
}
.transcript-total-title {
  font-size: 14px;
  padding: 3px 0;
}

tbody tr:hover {
  background-color: #fff;
}
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
.export-button {
  position: absolute;
  right: 20px;
  width: 140px;
  top: 80px;
}
</style>