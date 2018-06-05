<template>
    <div class="m-auto" id="aloha">
        <div class="row justify-content-center">
            <InputData></InputData>
            <OutputResults></OutputResults>
        </div>
        <div class="row justify-content-center">
            <MyBarChart name="Обработано пакетов" :data="packagesLeavedSystem "></MyBarChart>
            <MyBarChart name="Коллизии" :data="collisionData"></MyBarChart>
        </div>
    </div>
</template>
<script>
    import InputData from './modules/InputData'
    import OutputResults from './modules/OutputResults'
    import MyBarChart from './modules/Charts/MyBarChart'
    export default {
        components: {
            InputData,
            OutputResults,
            MyBarChart
        },
        computed: {
            packagesLeavedSystem() {
                return {
                    labels: ['Адаптивный', 'Неадаптивный'],
                    dataset: [this.$store.getters.AdaptedPackagesLeavedSystem, this.$store.getters.NotAdaptedPackagesLeavedSystem],
                    colors: ['rgba(210, 142, 202, 0.7)', 'rgba(101, 106, 187, 0.7)']
                }
            },
            collisionData: function () {
                return {
                    labels: ['Адаптивный', 'Неадаптивный'],
                    dataset: [this.$store.getters.AdaptedCollisions, this.$store.getters.NotAdaptedCollisions],
                    colors: ['rgba(0, 154, 9, 0.7)', 'rgba(248, 121, 121, 0.7)']
                }
            }
        },
    }
</script>
<style>
    .chart {
        max-width: 350px;
        margin: 150px auto;
    }
</style>
