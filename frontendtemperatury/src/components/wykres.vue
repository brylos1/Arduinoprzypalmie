<template>
    <canvas id="myChart" width="400" height="200"></canvas>
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
  SubTitle
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
        plugins: {
      legend: {
        labels: {
          color: "white",
          
        }
      }
    },
        scales: {
            y: {  
        ticks: {
          color: "white",
          stepSize: 1,

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
          stepSize: 1,
          

        }
      },
        }
    }
});
myChart;
        }
    }
</script>