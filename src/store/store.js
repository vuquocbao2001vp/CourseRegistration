import { createStore } from 'vuex'
import student from './modules/student.js'
import component from './modules/component.js'

const store = createStore({
  modules: {
    student,
    component,
  },
})

export default store