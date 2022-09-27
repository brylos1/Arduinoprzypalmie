<template>
    <canvas id="myChart"></canvas>
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
        mounted(){
            const ctx = document.getElementById('myChart');
            const myChart = new Chart(ctx, {
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
myChart;
        }
    }
</script>
<style scoped>
    canvas{
        height: 800px;
    }
    @media only screen and (max-width: 600px){
        canvas{
            height: 400px;
        }
    }
</style>