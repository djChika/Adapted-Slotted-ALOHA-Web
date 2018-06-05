//InputData Store

const state = {
    numberOfStations: 10,
    inputFlow: 0.5,
    numberOfFrames: 1000,
    numberOfIterations: 1
}

const getters = {
    NumberOfStations: state => state.numberOfStations,
    InputFlow: state => state.inputFlow,
    NumberOfFrames: state => state.numberOfFrames,
    NumberOfIterations: state => state.numberOfIterations
}

const mutations = {
    NumberOfStations(state, value) {
        state.numberOfStations = value;
    },
    InputFlow(state, value) {
        state.inputFlow = value;
    },
    NumberOfFrames(state, value) {
        state.numberOfFrames = value;
    },
    NumberOfIterations(state, value) {
        state.numberOfIterations = value;
    }

}

export default ({
    state,
    getters,
    mutations
})
