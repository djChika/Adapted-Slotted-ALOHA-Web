import { Bar, mixins } from 'vue-chartjs'
const { reactiveProp } = mixins

export default {
    extends: Bar,
    mixins: [reactiveProp],
    props: ['options'],
    mounted() {
        // this.chartData is created in the mixin.
        // If you want to pass options please create a local options object

        Chart.scaleService.updateScaleDefaults('linear', {
            ticks: {
                min: 0
            }
        });
        Chart.defaults.global.legend.display = false;
        this.renderChart(this.chartData, this.options)
    }
}
