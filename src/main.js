import { createApp } from 'vue'
import App from './App.vue'
import router from '../src/router/router'
import 'devextreme/dist/css/dx.light.css';

import DxSelectBox from "devextreme-vue/select-box"
import DxTextBox from "devextreme-vue/text-box"
import DxCheckBox from "devextreme-vue/check-box"
import DxButton from 'devextreme-vue/button';
import DxValidationSummary from 'devextreme-vue/validation-summary';
import {
  DxValidator,
  DxRequiredRule,
  DxEmailRule,
} from 'devextreme-vue/validator';

import BaseButton from '../src/components/base/BaseButton.vue'
import BaseTable from '../src/components/base/BaseTable.vue'
import BasePopup from '../src/components/base/BasePopup.vue'
import BaseLoader from '../src/components/base/BaseLoader.vue'
import BaseToast from '../src/components/base/BaseToast.vue'

import store from '../src/store/store.js'
import UUID from 'vue-uuid'

import isMatchDate from '../src/constants/extensions/compareDate'
import compareObjects from '../src/constants/extensions/compareObjects'

const app = createApp(App);

app.component("BaseButton", BaseButton);
app.component("BaseTable", BaseTable);
app.component("BasePopup", BasePopup);
app.component("BaseLoader", BaseLoader);
app.component("BaseToast", BaseToast);

app.component("DxSelectBox", DxSelectBox);
app.component("DxTextBox", DxTextBox);
app.component("DxCheckBox", DxCheckBox);
app.component("DxButton", DxButton);
app.component("DxValidationSummary", DxValidationSummary);
app.component("DxValidator", DxValidator);
app.component("DxRequiredRule", DxRequiredRule);
app.component("DxEmailRule", DxEmailRule);

app.use(store)

app.config.globalProperties.$isMatchDate = isMatchDate
app.config.globalProperties.$compareObjects = compareObjects


app.use(UUID)
app.use(router).mount("#app");
