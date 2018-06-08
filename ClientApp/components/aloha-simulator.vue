<template>
    <div id="aloha" class="m-auto px-2 border rounded-bottom">
        <div class="row justify-content-center">
            <InputData></InputData>
            <MyRadarChart name="Станции" :data="radarDataset"></MyRadarChart>
            <OutputResults></OutputResults>
        </div>
        <div class="row justify-content-center">
            <MyBarChart name="Обработано пакетов" :data="packagesLeavedSystemDataset"></MyBarChart>
            <MyBarChart name="Коллизии" :data="collisionDataset"></MyBarChart>
            <MyBarChart name="Среднее время заявки в системе" :data="AverageOfPackagesLifeTimeDataset"></MyBarChart>
        </div>
    </div>
</template>
<script>
    import InputData from './AlohaSimulator/InputData'
    import OutputResults from './AlohaSimulator/OutputResults'
    import MyBarChart from './AlohaSimulator/Charts/MyBarChart'
    import MyRadarChart from './AlohaSimulator/Charts/MyRadarChart'
    export default {
        components: {
            InputData,
            OutputResults,
            MyBarChart,
            MyRadarChart
        },
        computed: {
            radarDataset() {
                return {
                    dataName: 'Интенсивность входного потока',
                    labels: [...Array(this.$store.getters.NumberOfStations).keys()],
                    dataset: Array(this.$store.getters.NumberOfStations).fill(this.$store.getters.InputFlow),
                    colors: ['rgba(63,0,223,0.65)']
                }
            },
            packagesLeavedSystemDataset() {
                return {
                    labels: ['Адаптивный', 'Неадаптивный'],
                    dataset: [this.$store.getters.AdaptedPackagesLeavedSystem, this.$store.getters.NotAdaptedPackagesLeavedSystem],
                    colors: ['rgba(210, 142, 202, 0.7)', 'rgba(101, 106, 187, 0.7)']
                }
            },
            collisionDataset() {
                return {
                    labels: ['Адаптивный', 'Неадаптивный'],
                    dataset: [this.$store.getters.AdaptedCollisions, this.$store.getters.NotAdaptedCollisions],
                    colors: ['rgba(0, 154, 9, 0.7)', 'rgba(248, 121, 121, 0.7)']
                }
            },
            AverageOfPackagesLifeTimeDataset() {
                return {
                    labels: ['Адаптивный', 'Неадаптивный'],
                    dataset: [this.$store.getters.AdaptedAverageOfPackagesLifeTime, this.$store.getters.NotAdaptedAverageOfPackagesLifeTime],
                    colors: ['rgba(247, 184, 1, 0.7)', 'rgba(243, 91, 4, 0.7)']
                }
            }

        },
    }
</script>
<style>
    #aloha {
        background-color: rgb(253,253,253);
    }
</style>
