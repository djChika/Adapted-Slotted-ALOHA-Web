//OutputResults Store

const state = {
    adapted: {
        generatedPackages: null,
        packagesLeavedSystem: null,
        backloggedPackages: null,
        collisions: null,
        averageOfBackloggedPackages: null,
        averageOfPackagesLifeTime: null,
    },
    notAdapted: {
        generatedPackages: null,
        packagesLeavedSystem: null,
        backloggedPackages: null,
        collisions: null,
        averageOfBackloggedPackages: null,
        averageOfPackagesLifeTime: null,
    }
}

const getters = {
    AdaptedGeneratedPackages: state => state.adapted.generatedPackages,
    AdaptedPackagesLeavedSystem: state => state.adapted.packagesLeavedSystem,
    AdaptedBackloggedPackages: state => state.adapted.backloggedPackages,
    AdaptedCollisions: state => state.adapted.collisions,
    AdaptedAverageOfBackloggedPackages: state => state.adapted.averageOfBackloggedPackages,
    AdaptedAverageOfPackagesLifeTime: state => state.adapted.averageOfPackagesLifeTime,

    NotAdaptedGeneratedPackages: state => state.notAdapted.generatedPackages,
    NotAdaptedPackagesLeavedSystem: state => state.notAdapted.packagesLeavedSystem,
    NotAdaptedBackloggedPackages: state => state.notAdapted.backloggedPackages,
    NotAdaptedCollisions: state => state.notAdapted.collisions,
    NotAdaptedAverageOfBackloggedPackages: state => state.notAdapted.averageOfBackloggedPackages,
    NotAdaptedAverageOfPackagesLifeTime: state => state.notAdapted.averageOfPackagesLifeTime
}

const mutations = {
    AdaptedGeneratedPackages(state, value) {
        state.adapted.generatedPackages = value;
    },
    AdaptedPackagesLeavedSystem(state, value) {
        state.adapted.packagesLeavedSystem = value;
    },
    AdaptedBackloggedPackages(state, value) {
        state.adapted.backloggedPackages = value;
    },
    AdaptedCollisions(state, value) {
        state.adapted.collisions = value;
    },
    AdaptedAverageOfBackloggedPackages(state, value) {
        state.adapted.averageOfBackloggedPackages = value;
    },
    AdaptedAverageOfPackagesLifeTime(state, value) {
        state.adapted.averageOfPackagesLifeTime = value;
    },

    NotAdaptedGeneratedPackages(state, value) {
        state.notAdapted.generatedPackages = value;
    },
    NotAdaptedPackagesLeavedSystem(state, value) {
        state.notAdapted.packagesLeavedSystem = value;
    },
    NotAdaptedBackloggedPackages(state, value) {
        state.notAdapted.backloggedPackages = value;
    },
    NotAdaptedCollisions(state, value) {
        state.notAdapted.collisions = value;
    },
    NotAdaptedAverageOfBackloggedPackages(state, value) {
        state.notAdapted.averageOfBackloggedPackages = value;
    },
    NotAdaptedAverageOfPackagesLifeTime(state, value) {
        state.notAdapted.averageOfPackagesLifeTime = value;
    },



}

const actions = {
    updateResults(context, payload) {
        axios({
            method: 'post',
            url: '/api/Aloha/Calculation',
            data: payload
        }).then(response => {
            //console.log(response.data);
            let data = response.data;
            state.adapted.generatedPackages = data.adapted.packagesGenerated.toFixed(0);
            state.adapted.packagesLeavedSystem = data.adapted.packagesLeavedSystem.toFixed(0);
            state.adapted.backloggedPackages = data.adapted.backloggedPackages.toFixed(0);
            state.adapted.collisions = data.adapted.collisions.toFixed(0);
            state.adapted.averageOfBackloggedPackages = data.adapted.averageOfBackloggedPackages.toFixed(0);
            state.adapted.averageOfPackagesLifeTime = data.adapted.averageOfPackagesLifeTime.toFixed(2);

            state.notAdapted.generatedPackages = data.notAdapted.packagesGenerated.toFixed(0);
            state.notAdapted.packagesLeavedSystem = data.notAdapted.packagesLeavedSystem.toFixed(0);
            state.notAdapted.backloggedPackages = data.notAdapted.backloggedPackages.toFixed(0);
            state.notAdapted.collisions = data.notAdapted.collisions.toFixed(0);
            state.notAdapted.averageOfBackloggedPackages = data.notAdapted.averageOfBackloggedPackages.toFixed(0);
            state.notAdapted.averageOfPackagesLifeTime = data.notAdapted.averageOfPackagesLifeTime.toFixed(2);

        });
        //console.log(payload);
    }
}

import axios from 'axios'

export default ({
    state,
    getters,
    mutations,
    actions
})
