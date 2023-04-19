const state = {
  loading: false, // hiển thị loading
  toastMessage: null, // hiển thị toast
  isLoginSuccess: undefined, // trạng thái đăng nhập
};

const getters = {
  loading: state => state.loading,
  toastMessage: state => state.toastMessage,
  isLoginSuccess: (state) => state.isLoginSuccess,
};
const mutations = {
  /**
   * Ẩn hiện loading
   */
  setLoading(state, value) {
    state.loading = value;
  },
  /**
   * Thông báo của toast message
   */
  setToastMessage(state, message){
    state.toastMessage = message;
  },
  /**
   * Xóa message của toast
   */
  clearToastMessage(state){
    state.toastMessage = "";
  },
  setLoginStatus(state, isSuccess){
    state.isLoginSuccess = isSuccess;
  },
}
const actions = {
  /**
   * Hiển thị toast trong 3s
   */
  showToastMessage({ commit }, message) {
    commit("setToastMessage", message);
    setTimeout(() => {
      commit("clearToastMessage");
    }, 3000); // Hiển thị Toast trong 3 giây
  },
}
export default {
  state,
  getters,
  mutations,
  actions
};
