<template>
  <div class="registration-page">
    <!-- <div class="search-input flex">
      <div class="text-box">
        <DxTextBox
          mode="search"
          placeholder="Tìm kiếm môn học"
          value-change-event="keyup"
          @value-changed="getTextSearch"
        />
      </div>
    </div> -->
    <div class="registration-page-table">
      <base-table>
        <template #table-header>
          <tr>
            <th style="width: 40px"></th>
            <th class="td-text-left" style="width: 140px">Mã môn học</th>
            <th class="td-text-left" style="width: 200px">Tên môn học</th>
            <th style="width: 40px">Số tín chỉ</th>
            <th style="width: 40px">Điểm</th>
            <th style="width: 120px">Giảng viên</th>
            <th style="width: 120px">Lịch học</th>
            <th style="width: 120px">Giảng đường</th>
          </tr>
        </template>
        <template #table-body>
          <tr
            v-for="(course, index) in subjects"
            :key="index"
            :class="{
              'row-disabled': isDuplicate[index],
              'row-selected': isCheck[index],
            }"
          >
            <td class="td-text-center">
              <div @click="selectCourse(course.CourseID, index)">
                <DxCheckBox
                  v-model="isCheck[index]"
                  :disabled="isDuplicate[index]"
                />
              </div>
            </td>
            <td>{{ course.CourseCode }}</td>
            <td>{{ course.CourseName }}</td>
            <td class="td-text-center">{{ course.Credit }}</td>
            <td class="td-text-center">{{ course.Score }}</td>
            <td class="td-text-center">{{ course.Teacher }}</td>
            <td class="td-text-center">{{ course.Schedule }}</td>
            <td class="td-text-center">{{ course.Amphitheater }}</td>
          </tr>
        </template>
      </base-table>
    </div>
    <div class="result-table">
      <base-table>
        <template #table-header>
          <tr>
            <th style="width: 20px">STT</th>
            <th class="td-text-left" style="width: 100px">Mã môn học</th>
            <th class="td-text-left" style="width: 120px">Tên môn học</th>
            <th style="width: 36px">Số tín chỉ</th>
            <th style="width: 120px">Trạng thái</th>
            <th style="width: 120px">Lịch học</th>
            <th style="width: 120px">Giảng đường</th>
            <th style="width: 20px"></th>
          </tr>
        </template>
        <template #table-body>
          <tr v-for="(subject, index) in enrollment" :key="index">
            <td class="td-text-center">{{ index + 1 }}</td>
            <td>{{ subject.CourseCode }}</td>
            <td>{{ subject.CourseName }}</td>
            <td class="td-text-center">{{ subject.Credit }}</td>
            <td class="td-text-center">
              {{ regisStatus[subject.Status - 1] }}
            </td>
            <td class="td-text-center">
              {{ subject.Schedule }}
            </td>
            <td class="td-text-center">{{ subject.Amphitheater }}</td>
            <td>
              <div class="td-icon flex">
                <div
                  @click="removeCourse(subject.CourseID)"
                  class="icon-delete icon-center"
                  title="Xóa"
                ></div>
              </div>
            </td>
          </tr>
        </template>
      </base-table>
    </div>
    <div class="button-flex flex">
      <div class="total-regis">
        Số môn học đã đăng ký: {{ enrollment.length }}
      </div>
      <div class="button" @click="deleteEnrollmentOnClick">
        <base-button buttonType="red-square" buttonName="Xóa" />
      </div>
      <div class="button" @click="confirmRegistration">
        <base-button buttonType="regular-square" buttonName="Ghi nhận" />
      </div>
    </div>
  </div>
</template>
<script>
import BaseTable from "@/components/base/BaseTable.vue";
import { mapGetters, mapMutations, mapActions } from "vuex";
import BaseButton from "@/components/base/BaseButton.vue";
export default {
  components: { BaseTable, BaseButton },
  data() {
    return {
      isCheck: [],
      isDuplicate: [],
      enrollment: [],
      regisStatus: [
        "Đăng ký lần đầu",
        "Học lại",
        "Học cải thiện",
        "Đăng ký tự do",
      ],
      timeout: null,
      textSearch: null,
      confirmAction: null, // 1-Thêm mới, 2-Sửa
      oldEnrollment: null,
    };
  },
  computed: {
    ...mapGetters(["subjects", "enrollments"]),
  },
  watch: {
    enrollments: function (value) {
      this.oldEnrollment = [...value.enrollment];
      this.enrollment = value.enrollment;
    },
    enrollment: {
      handler: function (value) {
        for (let i = 0; i < this.subjects.length; i++) {
          let id = this.subjects[i].CourseID;
          let course = value.find((item) => item.CourseID == id);
          if (course) {
            this.isCheck[i] = true;
          } else {
            this.isCheck[i] = false;
            let schedule = this.subjects[i].Schedule;
            let check = value.find(
              (item) => this.$isMatchDate(item.Schedule, schedule) === true
            );
            if (check) {
              this.isDuplicate[i] = true;
            } else {
              this.isDuplicate[i] = false;
            }
          }
        }
      },
      deep: true,
    },
    textSearch: function (value) {
      this.getSubjects({
        id: "1113bff9-7186-5b43-68be-406293204378",
        searchKey: value,
      });
    },
  },
  mounted() {
    this.loadData();
  },
  methods: {
    ...mapMutations(["setSubjects", "setEnrollments"]),
    ...mapActions([
      "getSubjects",
      "getEnrollments",
      "insertEnrollments",
      "updateEnrollments",
      "deleteEnrollments",
    ]),
    loadData() {
      this.getSubjects({
        id: "1113bff9-7186-5b43-68be-406293204378",
        searchKey: "",
      }).then(() => {
        this.getEnrollments("1113bff9-7186-5b43-68be-406293204378");
      });
    },
    selectCourse(courseId, index) {
      if (this.isDuplicate[index] !== true) {
        if (!this.isCheck[index]) {
          this.enrollment = this.enrollment.filter(
            (course) => course.CourseID !== courseId
          );
        } else {
          let course = this.subjects.find((item) => item.CourseID == courseId);
          if (course.Score == null) course.Status = 1;
          else if (course.Score == 0) course.Status = 2;
          else if (course.Score > 0 && course.Score < 2) course.Status = 3;
          else course.Status = 4;
          this.enrollment.splice(this.enrollment.length, 0, course);
        }
      }
    },
    getTextSearch(data) {
      clearTimeout(this.timeout);
      var self = this;
      this.timeout = setTimeout(function () {
        self.textSearch = data.value;
      }, 500);
    },
    removeCourse(courseId) {
      this.enrollment = this.enrollment.filter(
        (course) => course.CourseID !== courseId
      );
    },
    confirmRegistration() {
      if (this.enrollment.length > 0) {
        if (this.oldEnrollment.length > 0) this.confirmAction = 2;
        else if (this.oldEnrollment.length == 0) this.confirmAction = 1;
        if (!this.$compareObjects(this.oldEnrollment, this.enrollment)) {
          let listCourseId = this.enrollment
            .map((item) => item.CourseID)
            .join(",");
          let listStatus = this.enrollment.map((item) => item.Status).join(",");
          if (this.confirmAction == 1) {
            this.insertEnrollments({
              studentId: "1113bff9-7186-5b43-68be-406293204378",
              listCourseId: listCourseId,
              listStatus: listStatus,
            });
            this.oldEnrollment = [...this.enrollment];
          } else if (this.confirmAction == 2) {
            this.updateEnrollments({
              studentId: "1113bff9-7186-5b43-68be-406293204378",
              listCourseId: listCourseId,
              listStatus: listStatus,
            });
            this.oldEnrollment = [...this.enrollment];
          }
        }
      } else {
        alert("Bạn cần chọn môn học trước khi nhấn Ghi nhận.");
      }
    },
    deleteEnrollmentOnClick() {
      if (this.enrollment.length > 0) {
        if (confirm("Bạn có chắc chắn muốn xóa danh sách đăng ký học không?")) {
          this.deleteEnrollments("1113bff9-7186-5b43-68be-406293204378");
          this.enrollment = [];
          this.oldEnrollment = [];
        }
      } else {
        alert("Bạn chưa đăng ký môn học nào.")
      }
    },
  },
};
</script>
<style scoped>
.registration-page {
  padding: 16px 0;
  position: relative;
}
.registration-page-table {
  width: 100%;
  height: calc(100vh - 368px);
  box-sizing: border-box;
  overflow: auto;
}
.result-table {
  margin-top: 16px;
  height: 179px;
  box-sizing: border-box;
  overflow: auto;
}
.search-input {
  width: 100%;
  padding-bottom: 8px;
  justify-content: flex-end;
}
.text-box {
  width: 320px;
}
.button-flex {
  width: 100%;
  justify-content: flex-end;
  margin-top: 12px;
}
.button {
  margin-left: 8px;
}
.td-icon {
  width: 100%;
  height: 100%;
  justify-content: center;
}
.icon-delete {
  cursor: pointer;
}
.total-regis {
  font-size: 14px;
  margin-right: 24px;
}
</style>