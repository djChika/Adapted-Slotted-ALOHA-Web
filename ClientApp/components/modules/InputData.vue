<template>
    <div id="inputModule" class="card m-3 input-card">

        <h6 class="card-header text-center">
            Входные данные
        </h6>

        <div class="card-body">

            <div class="input-group my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text input-label" for="inputGroupSelect01">Количество станций </label>
                </div>
                <select class="custom-select" id="inputGroupSelect01" v-model="numberOfStations">
                    <option v-for="value in inputValues.numberOfStations" :value="value">{{value}}</option>
                </select>
            </div>

            <div class="input-group my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text input-label" for="inputGroupSelect01">Интенсив. вх. потока </label>
                </div>
                <select class="custom-select" id="inputGroupSelect01" v-model="inputFlow">
                    <option v-for="value in inputValues.inputFlow" :value="value">{{value}}</option>
                </select>
            </div>

            <div class="input-group my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text input-label" for="inputGroupSelect01">Количество фреймов </label>
                </div>
                <select class="custom-select" id="inputGroupSelect01" v-model="numberOfFrames">
                    <option v-for="value in inputValues.numberOfFrames" :value="value">{{value}}</option>
                </select>
            </div>

            <div class="input-group my-3">
                <div class="input-group-prepend">
                    <label class="input-group-text input-label" for="inputGroupSelect01">Количество итераций </label>
                </div>
                <select class="custom-select" id="inputGroupSelect01" v-model="numberOfIterations">
                    <option v-for="value in inputValues.numberOfIterations" :value="value">{{value}}</option>
                </select>
            </div>

            <div class="row justify-content-center">
                <button class="btn btn-outline-primary mt-3" style="width:100px" v-on:click="calculate">Анализ</button>
            </div>

        </div>

    </div>
</template>

<script>
    //import store from '../../store/index';
    export default {
        name: 'InputData',
        data: () => ({
            inputValues: {
                numberOfStations: [1, 3, 5, 10, 15, 20, 30, 50, 100],
                inputFlow: [0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0],
                numberOfFrames: [100, 500, 1000, 5000, 10000, 50000, 100000],
                numberOfIterations: [1, 3, 5, 10, 15, 20]
            }
        }),
        computed: {
            numberOfStations: {
                get() {
                    return this.$store.getters.NumberOfStations
                },
                set(value) {
                    this.$store.commit('NumberOfStations', value)
                    //console.log(this.$store.getters.NumberOfStations)
                }
            },
            inputFlow: {
                get() {
                    return this.$store.getters.InputFlow
                },
                set(value) {
                    this.$store.commit('InputFlow', value)
                    //console.log(this.$store.getters.InputFlow)

                }
            },
            numberOfFrames: {
                get() {
                    return this.$store.getters.NumberOfFrames
                },
                set(value) {
                    this.$store.commit('NumberOfFrames', value)
                    //console.log(this.$store.getters.NumberOfFrames)

                }
            },
            numberOfIterations: {
                get() {
                    return this.$store.getters.NumberOfIterations
                },
                set(value) {
                    this.$store.commit('NumberOfIterations', value)
                    //console.log(this.$store.getters.NumberOfIterations)

                }
            }
        },
        methods: {
            calculate: function () {
                let payload = {
                    numberOfStations: this.numberOfStations,
                    inputFlow: this.inputFlow,
                    numberOfFrames: this.numberOfFrames,
                    numberOfIterations: this.numberOfIterations
                };
                this.$store.dispatch('updateResults', payload);
            }
        }
    }
</script>

<style>
    .input-card {
        //max-width: 350px;
    }

    .input-label {
        width: 179px;
    }
</style>
