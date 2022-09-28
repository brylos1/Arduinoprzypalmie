<template>
  <div id="chartwrap">
     <canvas id="myChart"></canvas>
  </div>
   
</template>
<script>
    import {
  Chart,
  ArcElement,
  LineElement,
  BarElement,
  PointElement,
  BarController,
  BubbleController,
  DoughnutController,
  LineController,
  PieController,
  PolarAreaController,
  RadarController,
  ScatterController,
  CategoryScale,
  LinearScale,
  LogarithmicScale,
  RadialLinearScale,
  TimeScale,
  TimeSeriesScale,
  Decimation,
  Filler,
  Legend,
  Title,
  Tooltip,
  SubTitle
} from 'chart.js';
import zoomPlugin from 'chartjs-plugin-zoom'
Chart.register(
  ArcElement,
  LineElement,
  BarElement,
  PointElement,
  BarController,
  BubbleController,
  DoughnutController,
  LineController,
  PieController,
  PolarAreaController,
  RadarController,
  ScatterController,
  CategoryScale,
  LinearScale,
  LogarithmicScale,
  RadialLinearScale,
  TimeScale,
  TimeSeriesScale,
  Decimation,
  Filler,
  Legend,
  Title,
  Tooltip,
  SubTitle,
  zoomPlugin
);

    export default{
        props:["labelsprops","datasetsprops"],
        data(){
          return{
            myChart:null,
            mounted:false,
          }
        },
        methods:{
          drawchart(){
            const ctx = document.getElementById('myChart');
            this.myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: this.labelsprops,
        datasets: this.datasetsprops
    },
    options: {
        responsive:true,
        maintainAspectRatio: false,
        plugins: {
      legend: {
        labels: {
          color: "white",
          
        }
      },
      zoom:{
        pan: {
          enabled:true,
          mode:'x'
        },
        zoom: {
            wheel: {
            enabled: true,
          },
          pinch: {
            enabled: true
          },
          mode: 'x',
        }
        }
      
    },
        scales: {
            y: {  
        ticks: {
          color: "white",
        },
        grid:{
            color:'white'
          },
      },
      x: { 
        grid:{
            color:'white'
          },
        ticks: {
          color: "white",
        }
      },
        }
    }
});
this.myChart;
          }
        },
        mounted(){
          this.drawchart()
          this.mounted=true
        },
        watch:{
          datasetsprops(newdatasets,olddatasets){
            if(this.mounted){
              const chart = document.getElementById('myChart');
              chart.remove();
              this.myChart.destroy();
              const wrap = document.getElementById('chartwrap');
              const newcanvas=document.createElement("canvas");
              newcanvas.setAttribute("id","myChart");
              newcanvas.style.cssText += "height: 650px;"
              wrap.appendChild(newcanvas);
            }

            this.drawchart();
          }
        }
    }
</script>
<style scoped>
    canvas{
        height: 650px;
    }
    @media only screen and (max-width: 600px){
        canvas{
            height: 650px;
        }
    }
</style>