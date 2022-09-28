<template>
    <div class="col-12 bc-purple py-5" >
        <h2>Aktualna temperatura <strong>Powietrza: <span>{{TeperaturaPowietrza}}</span>&deg;C</strong> Aktualna temperatura <strong>Gleby: <span>{{TemperaturaGleby}}</span>&deg;C</strong></h2>
    </div>
</template>
<script>
export default {
  data() {
    return { TeperaturaPowietrza: null,
    TemperaturaGleby:null,
    interval:null }
  },
  methods: {
    reNew() {
      this.$axios.get("https://palma.bieda.it/api/Palma/ostatni").then(response=>{
        this.TemperaturaGleby=response.data.temperaturaGleby;
      this.TeperaturaPowietrza=response.data.temperaturaPowietrza;

    }).catch(e => {
      this.TemperaturaGleby="Nie udało się pobrać danych";
      this.TeperaturaPowietrza="Nie udało się pobrać danych";
    })
    }
  },
  mounted() {
    this.reNew()
  },
  created(){
    this.interval = setInterval(() =>{
      this.reNew()},60000)
  },
  destroyed(){
    clearInterval(this.interval)
  }
    
}
</script>
<style>
    .bc-purple{
        background-color: #DA70D6;
        color: whitesmoke;
    }
</style>