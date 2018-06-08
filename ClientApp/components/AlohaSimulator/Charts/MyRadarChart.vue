<template>
    <div class="chart card justify-content-center m-3">
        <h6 class="card-header text-center">
            {{title}}
        </h6>
        <div class="card-body">
            <radar-chart :chart-data="chartdata"></radar-chart>
        </div>
    </div>
</template>
<script>
    import RadarChart from './RadarChart.js'
    export default {
        components: {
            RadarChart
        },

        props: ['name', 'data'],
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
                            label: this.data.dataName,
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
    .chart {
        max-width: 330px;
        margin: 150px auto;
    }
</style>
