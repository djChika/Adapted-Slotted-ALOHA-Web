<template>
    <div class="m-auto" id="aloha">
        <div class="row justify-content-center">
            <div class="card m-3 input-card">
                <h6 class="card-header text-center">
                    Входные данные
                </h6>
                <div class="card-body">
                    <div class="input-group my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-input" for="inputGroupSelect01">Количество станций </label>
                        </div>
                        <select class="custom-select" id="inputGroupSelect01" v-model="inputParameters.numberOfStations">
                            <option v-for="value in inputValues.numberOfStations" :value="value">{{value}}</option>
                        </select>
                    </div>

                    <div class="input-group my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-input" for="inputGroupSelect01">Интенсив. вх. потока </label>
                        </div>
                        <select class="custom-select" id="inputGroupSelect01" v-model="inputParameters.inputFlow">
                            <option v-for="value in inputValues.inputFlow" :value="value">{{value}}</option>
                        </select>
                    </div>

                    <div class="input-group my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-input" for="inputGroupSelect01">Количество фреймов </label>
                        </div>
                        <select class="custom-select" id="inputGroupSelect01" v-model="inputParameters.numberOfFrames">
                            <option v-for="value in inputValues.numberOfFrames" :value="value">{{value}}</option>
                        </select>
                    </div>

                    <div class="input-group my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-input" for="inputGroupSelect01">Количество итераций </label>
                        </div>
                        <select class="custom-select" id="inputGroupSelect01" v-model="inputParameters.numberOfIterations">
                            <option v-for="value in inputValues.numberOfIterations" :value="value">{{value}}</option>
                        </select>
                    </div>

                    <div class="row justify-content-center">
                        <button class="btn btn-outline-primary my-3" style="width:100px" v-on:click="calculate">Анализ</button>
                    </div>
                </div>
            </div>
            <div class="card m-3 result-card">
                <h6 class="card-header text-center">
                    Результаты
                </h6>
                <div class="card-body">
                    <div class="input-group input-group-sm my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-result" style="width:180px">Отправлено пакетов </label>
                        </div>
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.adapted.generatedPackages">
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.notAdapted.generatedPackages">
                    </div>
                    <div class="input-group input-group-sm my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-result" style="width:180px">Обработано пакетов </label>
                        </div>
                        <input type="text" class="form-control text-center input-result label-adapted-packagesLeavedSystem" v-model="outputResults.adapted.packagesLeavedSystem">
                        <input type="text" class="form-control text-center input-result label-notAdapted-packagesLeavedSystem" v-model="outputResults.notAdapted.packagesLeavedSystem">
                    </div>
                    <div class="input-group input-group-sm my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-result">Осталось в очереди </label>
                        </div>
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.adapted.backloggedPackages">
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.notAdapted.backloggedPackages">
                    </div>

                    <div class="input-group input-group-sm my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-result">Число коллизий </label>
                        </div>
                        <input type="text" class="form-control text-center input-result label-adapted-collision" v-model="outputResults.adapted.collisions">
                        <input type="text" class="form-control text-center input-result label-notAdapted-collision" v-model="outputResults.notAdapted.collisions">
                    </div>

                    <div class="input-group input-group-sm my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-result">Ср. число заявок в очереди </label>
                        </div>
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.adapted.averageOfBackloggedPackages">
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.notAdapted.averageOfBackloggedPackages">
                    </div>
                    <div class="input-group input-group-sm my-3">
                        <div class="input-group-prepend">
                            <label class="input-group-text label-result">Ср. время заявки в системе </label>
                        </div>
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.adapted.averageOfPackagesLifeTime">
                        <input type="text" class="form-control text-center input-result" v-model="outputResults.notAdapted.averageOfPackagesLifeTime">
                    </div>
                </div>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="card small justify-content-center m-3">
                <h6 class="card-header text-center">
                    Обработано пакетов
                </h6>
                <div class="card-body">
                    <bar-chart :chart-data="chartsData.packagesLeavedSystem"></bar-chart>
                </div>
            </div>

            <div class="card small justify-content-center m-3">
                <h6 class="card-header text-center">
                    Коллизии
                </h6>
                <div class="card-body">
                    <bar-chart :chart-data="chartsData.collisionsData"></bar-chart>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import axios from 'axios'
    import $ from 'jquery'
    import LineChart from '../store/LineChart.js'
    import BarChart from '../store/BarChart.js'
    export default {
        components: {
            LineChart,
            BarChart
        },
        data: () => ({
            inputValues: {
                numberOfStations: [1, 3, 5, 10, 15, 20, 30, 50, 100],
                inputFlow: [0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0],
                numberOfFrames: [100, 500, 1000, 5000, 10000, 50000, 100000],
                numberOfIterations: [1, 3, 5, 10, 15, 20]
            },
            inputParameters: {
                numberOfStations: null,
                inputFlow: null,
                numberOfFrames: null,
                numberOfIterations: null
            },
            outputResults: {
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
            },
            chartsData: {
                collisionsData: null,
                packagesLeavedSystem: null
            }
        }),
        mounted: function () {

        },
        methods: {
            calculate: function () {
                axios({
                    method: 'post',
                    url: '/api/Aloha/Calculation',
                    data: {
                        NumberOfStations: this.inputParameters.numberOfStations,
                        InputFlow: this.inputParameters.inputFlow,
                        NumberOfFrames: this.inputParameters.numberOfFrames,
                        numberOfIterations: this.inputParameters.numberOfIterations
                    }
                }).then(response => {
                    console.log(response.data);
                    //this.findAverageInArray(this.dataFromServer.adapted.packagesGenerated);
                    this.updateResults(response.data);
                    this.fillChart(response.data);
                });
            },
            updateResults(data) {
                this.outputResults.adapted.generatedPackages = this.findAverageInArray(data.adapted.packagesGenerated).toFixed(0);
                this.outputResults.adapted.packagesLeavedSystem = this.findAverageInArray(data.adapted.packagesLeavedSystem).toFixed(0);
                this.outputResults.adapted.backloggedPackages = this.findAverageInArray(data.adapted.backloggedPackages).toFixed(0);
                this.outputResults.adapted.collisions = this.findAverageInArray(data.adapted.collisions).toFixed(0);
                this.outputResults.adapted.averageOfBackloggedPackages = this.findAverageInArray(data.adapted.averageOfBackloggedPackages).toFixed(0);
                this.outputResults.adapted.averageOfPackagesLifeTime = this.findAverageInArray(data.adapted.averageOfPackagesLifeTime).toFixed(2);

                this.outputResults.notAdapted.generatedPackages = this.findAverageInArray(data.notAdapted.packagesGenerated).toFixed(0);
                this.outputResults.notAdapted.packagesLeavedSystem = this.findAverageInArray(data.notAdapted.packagesLeavedSystem).toFixed(0);
                this.outputResults.notAdapted.backloggedPackages = this.findAverageInArray(data.notAdapted.backloggedPackages).toFixed(0);
                this.outputResults.notAdapted.collisions = this.findAverageInArray(data.notAdapted.collisions).toFixed(0);
                this.outputResults.notAdapted.averageOfBackloggedPackages = this.findAverageInArray(data.notAdapted.averageOfBackloggedPackages).toFixed(0);
                this.outputResults.notAdapted.averageOfPackagesLifeTime = this.findAverageInArray(data.notAdapted.averageOfPackagesLifeTime).toFixed(2);
            },
            fillChart(data) {
                this.chartsData.collisionsData = {
                    //labels: Array.from(Array(data.notAdapted.collisions.length).keys()),
                    datasets: [
                        {
                            label: 'Адаптивный алгоритм',
                            backgroundColor: '#009a09',
                            data: [Math.round(this.findAverageInArray(data.adapted.collisions))]
                        }, {
                            label: 'Неадаптивный алгоритм',
                            backgroundColor: '#f87979',
                            data: [Math.round(this.findAverageInArray(data.notAdapted.collisions))]
                        }
                    ]
                };

                this.chartsData.packagesLeavedSystem = {
                    //labels: Array.from(Array(data.notAdapted.collisions.length).keys()),
                    datasets: [
                        {
                            label: 'Адаптивный алгоритм',
                            backgroundColor: '#d28eca',
                            data: [Math.round(this.findAverageInArray(data.adapted.packagesLeavedSystem))]
                        }, {
                            label: 'Неадаптивный алгоритм',
                            backgroundColor: '#656abb',
                            data: [Math.round(this.findAverageInArray(data.notAdapted.packagesLeavedSystem))]
                        }
                    ]
                };
            },
            getRandomInt() {
                return Math.floor(Math.random() * (50 - 5 + 1)) + 5
            },
            findAverageInArray(arr) {
                //console.log("FIND AVERAGE");
                //console.log(arr);
                let count = arr.length;
                arr = arr.reduce((previous, current) => current += previous);
                arr /= count;
                //console.log(arr);
                return arr;
            }

        },
    }
</script>
<style>
    .small {
        max-width: 600px;
        margin: 150px auto;
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

    .input-card {
        //max-width: 350px;
    }

    .label-input {
        width: 179px;
    }

    .result-card {
        //max-width: 450px;
    }

    .input-result {
        max-width: 75px;
    }

    .label-result {
        min-width: 195px;
        max-width: 195px;
    }
</style>
