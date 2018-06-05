import Vue from 'vue'
import Vuex from 'vuex'
import inputData from './AlohaSimulator/inputData'
import outputResults from './AlohaSimulator/outputResults'

Vue.use(Vuex)


export default new Vuex.Store({
    modules: {
        inputData,
        outputResults
    }
});
