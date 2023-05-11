import { reactive } from 'vue';
import axios from 'axios';

const state = reactive({
  baseURL: 'https://localhost:44345/api',
  // baseURL: 'https://uetcourseregistration.azurewebsites.net/api',
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
  },
});

export const instanceAxios = axios.create({
  baseURL: state.baseURL ,
  headers: state.headers,
  // transformRequest: [(data, headers) => {
  //   if (data instanceof FormData) {
  //     // Set 'Content-Type' to 'multipart/form-data' for requests that contain a FormData object
  //     headers['Content-Type'] = 'multipart/form-data';
  //     return data;
  //   }
  //   // Handle other data formats as desired
  //   headers['Content-Type'] = 'application/json';
  //   return JSON.stringify(data);
  // }],
});
