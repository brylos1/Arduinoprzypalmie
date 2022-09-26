<template>
  <div class="container-fluid">
    <div class="row">
      <aktualneTemperaturyVue/>
      <WybierzDane/>
    </div>
    
  </div>
  
</template>

<script>
import aktualneTemperaturyVue from './components/aktualneTemperatury.vue';
import WybierzDaneVue from './components/WybierzDane.vue';
import WybierzDane from './components/WybierzDane.vue';


export default {
  name: 'App',
  components: {
    aktualneTemperaturyVue,
    WybierzDaneVue,
    WybierzDane
}
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  overflow-wrap: break-word;
}
</style>
