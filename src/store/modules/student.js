import { instanceAxios } from "../../constants/api/instanceAxios";
import router from '../../router/router'

const state = {
  token: null,
  student: null,
  transcripts: null,
  enrollments: null,
  subjects: null,
};

const getters = {
  token: (state) => state.token,
  student: (state) => state.student,
  transcripts: (state) => state.transcripts,
  enrollments: (state) => state.enrollments,
  subjects: (state) => state.subjects,
};
const mutations = {
  setToken(state, token){
    state.token = token;
    instanceAxios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  },
  setStudent(state, student){
    state.student = student
  },
  setTranscripts(state, data) {
    state.transcripts = data;
  },
  setEnrollments(state, data) {
    state.enrollments = data;
  },
  setSubjects(state, data) {
    state.subjects = data;
  },
};

const actions = {
  async getTranscipts({ commit }, id) {
    commit("setLoading", true);
    try {
      await instanceAxios
        .get(`/Students/student-transcript/${id}`)
        .then((response) => {
          commit("setTranscripts", response.data);
          commit("setLoading", false);
        });
    } catch (error) {
      commit("setLoading", false);
      console.log(error);
    }
  },
  async getSubjects({ commit }, { id, searchKey }) {
    commit("setLoading", true);
    try {
      await instanceAxios
        .get("/Students/student-subject", {
          params: {
            id: id,
            searchKey: searchKey,
          },
        })
        .then((response) => {
          commit("setSubjects", response.data.data);
          commit("setLoading", false);
        });
    } catch (error) {
      commit("setLoading", false);
      console.log(error);
    }
  },
  async getEnrollments({ commit }, id) {
    commit("setLoading", true);
    try {
      await instanceAxios
        .get(`/Students/student-enrollment/${id}`)
        .then((response) => {
          commit("setEnrollments", response.data);
          commit("setLoading", false);
        });
    } catch (error) {
      commit("setLoading", false);
      console.log(error);
    }
  },
  async insertEnrollments(
    { commit},
    { studentId, listCourseId, listStatus }
  ) {
    commit("setLoading", true);
    try {
      await instanceAxios
        .post("/Students/student-enrollment", {
          StudentID: studentId,
          ListCourseId: listCourseId,
          ListStatus: listStatus,
          Semester: "HK1-2024",
        })
        .then(() => {
          alert("Đăng ký thành công "+listCourseId.split(',').length+" môn học")
          commit("setLoading", false);
        });
    } catch (error) {
      commit("setLoading", false);
      console.log(error);
    }
  },
  async updateEnrollments(
    { commit},
    { studentId, listCourseId, listStatus }
  ) {
    commit("setLoading", true);
    try {
      await instanceAxios
        .put("/Students/student-enrollment", {
          StudentID: studentId,
          ListCourseId: listCourseId,
          ListStatus: listStatus,
          Semester: "HK1-2024",
        })
        .then(() => {
          alert("Đăng ký thành công "+listCourseId.split(',').length+" môn học")
          commit("setLoading", false);
        });
    } catch (error) {
      commit("setLoading", false);
      console.log(error);
    }
  },
  async deleteEnrollments({ commit }, id) {
    commit("setLoading", true);
    try {
      await instanceAxios
        .delete(`/Students/student-enrollment/${id}`)
        .then(() => {
          alert("Xóa danh sách đăng ký học thành công.");
          commit("setLoading", false);
        });
    } catch (error) {
      commit("setLoading", false);
      console.log(error);
    }
  },

  async login({ commit, dispatch }, { code, password }) {
    commit("setLoading", true);
    try {
      const response = await instanceAxios.post("/Auth/login", {
        StudentCode: code,
        Password: password,
      });
      commit("setToken", response.data.token);
      commit("setStudent", response.data.info);
      commit("setLoginStatus", true);
      // Set the logout timer to 1 hour
      setTimeout(() => {
        alert("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.");
        dispatch("logout");
      }, 2* 60 * 60 * 1000);
      localStorage.setItem("key", response.data.token);
      localStorage.setItem("info", JSON.stringify(response.data.info));
      commit("setLoading", false);
    } catch {
      commit("setLoading", false);
      commit("setLoginStatus", false);
    }
  },

  async logout({ commit}) {
    commit("setToken", null);
    commit("setStudent", null);
    commit("setLoginStatus", null);
    localStorage.removeItem("key");
    localStorage.removeItem("info");
    router.push({path: "/login"})
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
