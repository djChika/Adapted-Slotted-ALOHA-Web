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
                <input type="text" class="form-control text-center input-result" v-model="AnimatedAdaptedGeneratedPackages">
                <input type="text" class="form-control text-center input-result" v-model="AnimatedNotAdaptedGeneratedPackages">
            </div>
            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result" style="width:180px">Обработано пакетов </label>
                </div>
                <input type="text" class="form-control text-center input-result label-adapted-packagesLeavedSystem" v-model="AnimatedAdaptedPackagesLeavedSystem">
                <input type="text" class="form-control text-center input-result label-notAdapted-packagesLeavedSystem" v-model="AnimatedNotAdaptedPackagesLeavedSystem">
            </div>
            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Осталось в очереди </label>
                </div>
                <input type="text" class="form-control text-center input-result" v-model="AnimatedAdaptedBackloggedPackages">
                <input type="text" class="form-control text-center input-result" v-model="AnimatedNotAdaptedBackloggedPackages">
            </div>

            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Число коллизий </label>
                </div>
                <input type="text" class="form-control text-center input-result label-adapted-collision" v-model="AnimatedAdaptedCollisions">
                <input type="text" class="form-control text-center input-result label-notAdapted-collision" v-model="AnimatedNotAdaptedCollisions">
            </div>

            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Ср. число заявок в очереди </label>
                </div>
                <input type="text" class="form-control text-center input-result" v-model="AnimatedAdaptedAverageOfBackloggedPackages">
                <input type="text" class="form-control text-center input-result" v-model="AnimatedNotAdaptedAverageOfBackloggedPackages">
            </div>
            <div class="input-group input-group-sm my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text label-result">Ср. время заявки в системе </label>
                </div>
                <input type="text" class="form-control text-center input-result label-adapted-averageOfPackagesLifeTime" v-model="AnimatedAdaptedAverageOfPackagesLifeTime">
                <input type="text" class="form-control text-center input-result label-notadapted-averageOfPackagesLifeTime" v-model="AnimatedNotAdaptedAverageOfPackagesLifeTime">
            </div>

        </div>

    </div>
</template>

<script>
    export default {
        name: 'OutputResults',
        data: () => ({
            TempAdaptedGeneratedPackages: 0,
            TempNotAdaptedGeneratedPackages: 0,
            TempAdaptedPackagesLeavedSystem: 0,
            TempNotAdaptedPackagesLeavedSystem: 0,
            TempAdaptedBackloggedPackages: 0,
            TempNotAdaptedBackloggedPackages: 0,
            TempAdaptedCollisions: 0,
            TempNotAdaptedCollisions: 0,
            TempAdaptedAverageOfBackloggedPackages: 0,
            TempNotAdaptedAverageOfBackloggedPackages: 0,
            TempAdaptedAverageOfPackagesLifeTime: 0,
            TempNotAdaptedAverageOfPackagesLifeTime: 0
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
            },


            AnimatedAdaptedGeneratedPackages: {
                get() {
                    return this.TempAdaptedGeneratedPackages == 0
                        ? this.AdaptedGeneratedPackages
                        : this.TempAdaptedGeneratedPackages.toFixed(0)
                }
            },
            AnimatedNotAdaptedGeneratedPackages: {
                get() {
                    return this.TempNotAdaptedGeneratedPackages == 0
                        ? this.NotAdaptedGeneratedPackages
                        : this.TempNotAdaptedGeneratedPackages.toFixed(0)
                }
            },
            AnimatedAdaptedPackagesLeavedSystem: {
                get() {
                    return this.TempAdaptedPackagesLeavedSystem == 0
                        ? this.AdaptedPackagesLeavedSystem
                        : this.TempAdaptedPackagesLeavedSystem.toFixed(0)
                }
            },
            AnimatedNotAdaptedPackagesLeavedSystem: {
                get() {
                    return this.TempNotAdaptedPackagesLeavedSystem == 0
                        ? this.NotAdaptedPackagesLeavedSystem
                        : this.TempNotAdaptedPackagesLeavedSystem.toFixed(0)
                }
            },
            AnimatedAdaptedBackloggedPackages: {
                get() {
                    return this.TempAdaptedBackloggedPackages == 0
                        ? this.AdaptedBackloggedPackages
                        : this.TempAdaptedBackloggedPackages.toFixed(0)
                }
            },
            AnimatedNotAdaptedBackloggedPackages: {
                get() {
                    return this.TempNotAdaptedBackloggedPackages == 0
                        ? this.AdaptedBackloggedPackages
                        : this.TempNotAdaptedBackloggedPackages.toFixed(0)
                }
            },
            AnimatedAdaptedCollisions: {
                get() {
                    return this.TempAdaptedCollisions == 0
                        ? this.AdaptedCollisions
                        : this.TempAdaptedCollisions.toFixed(0)
                }
            },
            AnimatedNotAdaptedCollisions: {
                get() {
                    return this.TempNotAdaptedCollisions == 0
                        ? this.NotAdaptedCollisions
                        : this.TempNotAdaptedCollisions.toFixed(0)
                }
            },
            AnimatedAdaptedAverageOfBackloggedPackages: {
                get() {
                    return this.TempAdaptedAverageOfBackloggedPackages == 0
                        ? this.AdaptedAverageOfBackloggedPackages
                        : this.TempAdaptedAverageOfBackloggedPackages.toFixed(0)
                }
            },
            AnimatedNotAdaptedAverageOfBackloggedPackages: {
                get() {
                    return this.TempNotAdaptedAverageOfBackloggedPackages == 0
                        ? this.NotAdaptedAverageOfBackloggedPackages
                        : this.TempNotAdaptedAverageOfBackloggedPackages.toFixed(0)
                }
            },
            AnimatedAdaptedAverageOfPackagesLifeTime: {
                get() {
                    return this.TempAdaptedAverageOfPackagesLifeTime == 0
                        ? this.AdaptedAverageOfPackagesLifeTime
                        : this.TempAdaptedAverageOfPackagesLifeTime.toFixed(2)
                }
            },
            AnimatedNotAdaptedAverageOfPackagesLifeTime: {
                get() {
                    return this.TempNotAdaptedAverageOfPackagesLifeTime == 0
                        ? this.NotAdaptedAverageOfPackagesLifeTime
                        : this.TempNotAdaptedAverageOfPackagesLifeTime.toFixed(2)
                }
            },

        },
        watch: {
            AdaptedGeneratedPackages(newValue) {
                TweenLite.to(this.$data, 0.5, { TempAdaptedGeneratedPackages: newValue })
            },
            NotAdaptedGeneratedPackages(newValue) {
                TweenLite.to(this.$data, 0.5, { TempNotAdaptedGeneratedPackages: newValue })
            },
            AdaptedPackagesLeavedSystem(newValue) {
                TweenLite.to(this.$data, 0.5, { TempAdaptedPackagesLeavedSystem: newValue })
            },
            NotAdaptedPackagesLeavedSystem(newValue) {
                TweenLite.to(this.$data, 0.5, { TempNotAdaptedPackagesLeavedSystem: newValue })
            },
            AdaptedBackloggedPackages(newValue) {
                TweenLite.to(this.$data, 0.5, { TempAdaptedBackloggedPackages: newValue })
            },
            NotAdaptedBackloggedPackages(newValue) {
                TweenLite.to(this.$data, 0.5, { TempNotAdaptedBackloggedPackages: newValue })
            },
            AdaptedCollisions(newValue) {
                TweenLite.to(this.$data, 0.5, { TempAdaptedCollisions: newValue })
            },
            NotAdaptedCollisions(newValue) {
                TweenLite.to(this.$data, 0.5, { TempNotAdaptedCollisions: newValue })
            },
            AdaptedAverageOfBackloggedPackages(newValue) {
                TweenLite.to(this.$data, 0.5, { TempAdaptedAverageOfBackloggedPackages: newValue })
            },
            NotAdaptedAverageOfBackloggedPackages(newValue) {
                TweenLite.to(this.$data, 0.5, { TempNotAdaptedAverageOfBackloggedPackages: newValue })
            },
            AdaptedAverageOfPackagesLifeTime(newValue) {
                TweenLite.to(this.$data, 0.5, { TempAdaptedAverageOfPackagesLifeTime: newValue })
            },
            NotAdaptedAverageOfPackagesLifeTime(newValue) {
                TweenLite.to(this.$data, 0.5, { TempNotAdaptedAverageOfPackagesLifeTime: newValue })
            },
        }
    }
</script>

<style>
    .result-card {
        max-width: 370px;
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
        background: rgba(217,83,79,0.5);
    }

    .label-adapted-packagesLeavedSystem {
        background: rgba(195,155,255,0.6);
    }

    .label-notAdapted-packagesLeavedSystem {
        background: rgba(159,155,255,0.75);
    }

    .label-adapted-averageOfPackagesLifeTime {
        background: rgba(247, 200, 1, 0.5);
    }

    .label-notadapted-averageOfPackagesLifeTime {
        background: rgba(255, 87, 10, 0.55);
    }
</style>
