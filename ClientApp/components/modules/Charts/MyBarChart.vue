<template>
    <div class="chart card justify-content-center m-3">
        <h6 class="card-header text-center">
            {{title}}
        </h6>
        <div class="card-body">
            <bar-chart :chart-data="chartdata"></bar-chart>
        </div>
    </div>
</template>
<script>
    import BarChart from './BarChart.js'
    export default {
        components: {
            BarChart
        },

        props: ['name','data'],
        data() {
            return {
                title: this.name
            }
        },
        computed: {
            chartdata() {
                return {
                    labels: this.data.labels,
                    datasets: [
                        {
                            label: this.name,
                            backgroundColor: this.data.colors,
                            data: this.data.dataset
                        }
                    ]
                }
            },
        },
    }
</script>
<style>
</style>
