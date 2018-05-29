<template>
    <div id="aloha">
        <br />
        <table>
            <tbody>
                <tr>
                    <td>
                        <label>Количество станций: </label>
                    </td>
                    <td>
                        <select v-model="numberOfStations">
                            <option value="5">5</option>
                            <option value="10">10</option>
                            <option value="15">15</option>
                            <option value="20">20</option>
                            <option value="50">50</option>
                            <option value="100">100</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Входной поток: </label>
                    </td>
                    <td>
                        <select v-model="inputFlow">
                            <option value="0.1">0.1</option>
                            <option value="0.2">0.2</option>
                            <option value="0.3">0.3</option>
                            <option value="0.4">0.4</option>
                            <option value="0.5">0.5</option>
                            <option value="0.6">0.6</option>
                            <option value="0.7">0.7</option>
                            <option value="0.8">0.8</option>
                            <option value="0.9">0.9</option>
                            <option value="1.0">1.0</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Количество фреймов: </label>
                    </td>
                    <td>
                        <select v-model="numberOfFrames">
                            <option value="100">100</option>
                            <option value="500">500</option>
                            <option value="1000">1000</option>
                            <option value="5000">5000</option>
                            <option value="10000">10000</option>
                            <option value="50000">50000</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Количество итераций: </label>
                    </td>
                    <td>
                        <select v-model="numberOfIterations">
                            <option value="5">5</option>
                            <option value="10">10</option>
                            <option value="15">15</option>
                            <option value="20">20</option>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
        <input type="button" v-on:click="calculate" value="calculate" />
        <table>
            <tbody>
                <tr>
                    <th>
                        <label>Сгенерировано пакетов: </label>
                    </th>
                    <th>
                        <input type="text" v-model="generatedPackagesAdapted">
                    </th>
                    <th>
                        <input type="text" v-model="generatedPackagesNotAdapted">
                    </th>
                </tr>
                <tr>
                    <th>
                        <label>Обработано пакетов: </label>
                    </th>
                    <th>
                        <input type="text" v-model="packagesLeavedSystemAdapted">
                    </th>
                    <th>
                        <input type="text" v-model="packagesLeavedSystemNotAdapted">
                    </th>
                </tr>
                <tr>
                    <th>
                        <label>Осталось в очереди: </label>
                    </th>
                    <th>
                        <input type="text" v-model="backloggedPackagesAdapted">
                    </th>
                    <th>
                        <input type="text" v-model="backloggedPackagesNotAdapted">
                    </th>
                </tr>
                <tr>
                    <th>
                        <label>Число коллизий: </label>
                    </th>
                    <th>
                        <input type="text" v-model="collisionsAdapted">
                    </th>
                    <th>
                        <input type="text" v-model="collisionsNotAdapted">
                    </th>
                </tr>
                <tr>
                    <th>
                        <label>Среднее число заявок в очереди: </label>
                    </th>
                    <th>
                        <input type="text" v-model="averageOfBackloggedPackagesAdapted">
                    </th>
                    <th>
                        <input type="text" v-model="averageOfBackloggedPackagesNotAdapted">
                    </th>
                </tr>
                <tr>
                    <th>
                        <label>Среднее время заявки в системе: </label>
                    </th>
                    <th>
                        <input type="text" v-model="averageOfPackagesLifeTimeAdapted">
                    </th>
                    <th>
                        <input type="text" v-model="averageOfPackagesLifeTimeNotAdapted">
                    </th>
                </tr>
            </tbody>
        </table>
        <div class="small">
            <line-chart :chart-data="datacollection"></line-chart>
            <button @click="fillData()">Randomize</button>
        </div>
    </div>
</template>
<script>
    import axios from 'axios'
    import $ from 'jquery'
    import LineChart from '../store/LineChart.js'
    export default {
        components: {
            LineChart
        },
        data: () => ({
            numberOfStations: null,
            inputFlow: null,
            numberOfFrames: null,
            numberOfIterations: null,

            generatedPackagesAdapted: null,
            packagesLeavedSystemAdapted: null,
            backloggedPackagesAdapted: null,
            collisionsAdapted: null,
            averageOfBackloggedPackagesAdapted: null,
            averageOfPackagesLifeTimeAdapted: null,

            generatedPackagesNotAdapted: null,
            packagesLeavedSystemNotAdapted: null,
            backloggedPackagesNotAdapted: null,
            collisionsNotAdapted: null,
            averageOfBackloggedPackagesNotAdapted: null,
            averageOfPackagesLifeTimeNotAdapted: null,

            datacollection: null,
            dataFromServer: null
        }),
        mounted: function () {

        },
        methods: {
            calculate: function () {
                axios({
                    method: 'post',
                    url: '/api/Aloha/Calculation',
                    data: {
                        NumberOfStations: this.numberOfStations,
                        InputFlow: this.inputFlow,
                        NumberOfFrames: this.numberOfFrames,
                        numberOfIterations: this.numberOfIterations
                    }
                }).then(response => {
                    console.log(response.data);
                    this.dataFromServer = response.data;
                    //this.findAverageInArray(this.dataFromServer.adapted.packagesGenerated);
                    this.updateResults(this.dataFromServer);
                });
            },
            updateResults(data) {
                this.generatedPackagesAdapted = this.findAverageInArray(data.adapted.packagesGenerated);
                this.packagesLeavedSystemAdapted = this.findAverageInArray(data.adapted.packagesLeavedSystem);
                this.backloggedPackagesAdapted = this.findAverageInArray(data.adapted.backloggedPackages);
                this.collisionsAdapted = this.findAverageInArray(data.adapted.collisions);
                this.averageOfBackloggedPackagesAdapted = this.findAverageInArray(data.adapted.averageOfBackloggedPackages);
                this.averageOfPackagesLifeTimeAdapted = this.findAverageInArray(data.adapted.averageOfPackagesLifeTime);

                this.generatedPackagesNotAdapted = this.findAverageInArray(data.notAdapted.packagesGenerated);
                this.packagesLeavedSystemNotAdapted = this.findAverageInArray(data.notAdapted.packagesLeavedSystem);
                this.backloggedPackagesNotAdapted = this.findAverageInArray(data.notAdapted.backloggedPackages);
                this.collisionsNotAdapted = this.findAverageInArray(data.notAdapted.collisions);
                this.averageOfBackloggedPackagesNotAdapted = this.findAverageInArray(data.notAdapted.averageOfBackloggedPackages);
                this.averageOfPackagesLifeTimeNotAdapted = this.findAverageInArray(data.notAdapted.averageOfPackagesLifeTime);
            },
            fillData() {
                this.datacollection = {
                    labels: [this.getRandomInt(), this.getRandomInt()],
                    datasets: [
                        {
                            label: 'Data One',
                            backgroundColor: '#009a09',
                            data: [this.getRandomInt(), this.getRandomInt()]
                        }, {
                            label: 'Data One',
                            backgroundColor: '#f87979',
                            data: [this.getRandomInt(), this.getRandomInt()]
                        }
                    ]
                }
            },
            getRandomInt() {
                return Math.floor(Math.random() * (50 - 5 + 1)) + 5
            },
            findAverageInArray(arr) {
                console.log("FIND AVERAGE");
                console.log(arr);
                let count = arr.length;
                arr = arr.reduce((previous, current) => current += previous);
                arr /= count;
                console.log(arr);
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
</style>
