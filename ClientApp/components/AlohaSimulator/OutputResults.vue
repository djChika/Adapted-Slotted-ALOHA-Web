<template>
    <div id="outputResults" class="card m-3 result-card">

        <h6 class="card-header text-center">
            Результаты
        </h6>

        <div class="card-body">

            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result" style="width:180px">Отправлено пакетов </label>
                </div>
                <input type="text" class="form-control text-center input-result" v-model="AdaptedGeneratedPackages">
                <input type="text" class="form-control text-center input-result" v-model="NotAdaptedGeneratedPackages">
            </div>
            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result" style="width:180px">Обработано пакетов </label>
                </div>
                <input type="text" class="form-control text-center input-result label-adapted-packagesLeavedSystem" v-model="AdaptedPackagesLeavedSystem">
                <input type="text" class="form-control text-center input-result label-notAdapted-packagesLeavedSystem" v-model="NotAdaptedPackagesLeavedSystem">
            </div>
            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Осталось в очереди </label>
                </div>
                <input type="text" class="form-control text-center input-result" v-model="AdaptedBackloggedPackages">
                <input type="text" class="form-control text-center input-result" v-model="NotAdaptedBackloggedPackages">
            </div>

            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Число коллизий </label>
                </div>
                <input type="text" class="form-control text-center input-result label-adapted-collision" v-model="AdaptedCollisions">
                <input type="text" class="form-control text-center input-result label-notAdapted-collision" v-model="NotAdaptedCollisions">
            </div>

            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Ср. число заявок в очереди </label>
                </div>
                <input type="text" class="form-control text-center input-result" v-model="AdaptedAverageOfBackloggedPackages">
                <input type="text" class="form-control text-center input-result" v-model="NotAdaptedAverageOfBackloggedPackages">
            </div>
            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Ср. время заявки в системе </label>
                </div>
                <input type="text" class="form-control text-center input-result" v-model="AdaptedAverageOfPackagesLifeTime">
                <input type="text" class="form-control text-center input-result" v-model="NotAdaptedAverageOfPackagesLifeTime">
            </div>

        </div>

    </div>
</template>

<script>
    export default {
        name: 'OutputResults',
        data: () => ({

        }),
        computed: {
            AdaptedGeneratedPackages: {
                get() {
                    return this.$store.getters.AdaptedGeneratedPackages
                }
            },
            NotAdaptedGeneratedPackages: {
                get() {
                    return this.$store.getters.NotAdaptedGeneratedPackages
                }
            },
            AdaptedPackagesLeavedSystem: {
                get() {
                    return this.$store.getters.AdaptedPackagesLeavedSystem
                }
            },
            NotAdaptedPackagesLeavedSystem: {
                get() {
                    return this.$store.getters.NotAdaptedPackagesLeavedSystem
                }
            },
            AdaptedBackloggedPackages: {
                get() {
                    return this.$store.getters.AdaptedBackloggedPackages
                }
            },
            NotAdaptedBackloggedPackages: {
                get() {
                    return this.$store.getters.NotAdaptedBackloggedPackages
                }
            },
            AdaptedCollisions: {
                get() {
                    return this.$store.getters.AdaptedCollisions
                }
            },
            NotAdaptedCollisions: {
                get() {
                    return this.$store.getters.NotAdaptedCollisions
                }
            },
            AdaptedAverageOfBackloggedPackages: {
                get() {
                    return this.$store.getters.AdaptedAverageOfBackloggedPackages
                }
            },
            NotAdaptedAverageOfBackloggedPackages: {
                get() {
                    return this.$store.getters.NotAdaptedAverageOfBackloggedPackages
                }
            },
            AdaptedAverageOfPackagesLifeTime: {
                get() {
                    return this.$store.getters.AdaptedAverageOfPackagesLifeTime
                }
            },
            NotAdaptedAverageOfPackagesLifeTime: {
                get() {
                    return this.$store.getters.NotAdaptedAverageOfPackagesLifeTime
                }
            }
        },
    }
</script>

<style>
    .result-card {
        //max-width: 390px;
    }

    .label-result {
        min-width: 195px;
        max-width: 195px;
    }

    .input-result {
        max-width: 75px;
    }

    .label-adapted-collision {
        background: rgba(92,184,92,0.45);
    }

    .label-notAdapted-collision {
        background: rgba(217,83,79,0.45);
    }

    .label-adapted-packagesLeavedSystem {
        background: rgba(195,155,255,0.6);
    }

    .label-notAdapted-packagesLeavedSystem {
        background: rgba(159,155,255,0.75);
    }
</style>
