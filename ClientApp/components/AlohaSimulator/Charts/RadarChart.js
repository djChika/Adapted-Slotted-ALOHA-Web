import { Radar, mixins } from 'vue-chartjs'
const { reactiveProp } = mixins
var myoptions = {
    scale: {
        ticks: {
            min: 0,
            max: 1,
            fontSize:14
        },
        pointLabels: {
            fontSize: 12
        }
    }
};
export default {
    extends: Radar,
    mixins: [reactiveProp],
    props: ['options'],
    mounted() {
        // this.chartData is created in the mixin.
        // If you want to pass options please create a local options object
        //Chart.defaults.bar.scales.xAxes[0].barThickness  = 55;
        Chart.defaults.global.legend.display = false;
        this.renderChart(this.chartData, myoptions)
    }
}
