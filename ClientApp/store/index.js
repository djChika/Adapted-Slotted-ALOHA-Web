import Vue from 'vue'
import Vuex from 'vuex'
import inputData from './modules/inputData'
import outputResults from './modules/outputResults'

Vue.use(Vuex)


export default new Vuex.Store({
    modules: {
        inputData,
        outputResults
    }
});
