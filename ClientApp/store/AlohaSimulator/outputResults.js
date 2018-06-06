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
    updateResults(state, data) {
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
    }
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
            context.commit('updateResults', data);
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
