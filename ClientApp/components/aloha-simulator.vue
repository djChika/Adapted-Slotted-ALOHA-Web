<template>
    <div id="aloha" class="m-auto border rounded-bottom">
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
    import InputData from './AlohaSimulator/InputData'
    import OutputResults from './AlohaSimulator/OutputResults'
    import MyBarChart from './AlohaSimulator/Charts/MyBarChart'
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
            collisionData() {
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
    #aloha {
        background-color: rgb(253,253,253);
    }
</style>
