<template>
    <div class="col-12 bc-purple py-3 my-2" >
        <div>
            <h4>Wybierz dane do wyświetlenia</h4>
        </div>
        <div class="row px-5 justify-content-center">
            <div class="text-algin-left form-check form-check-inline col-md-auto">
  <input class="form-check-input" type="radio" name="grupaWykres" id="nic" value="none" checked v-model="checkradio">
  <label class="form-check-label" for="nic">Nie interesuje mnie cic poza aktualną temperaturą</label>
</div>
<div class="form-check form-check-inline text-algin-left col-md-auto">
  <input class="form-check-input" type="radio" name="grupaWykres" id="temperaturyy" value="temp" v-model="checkradio">
  <label class="form-check-label" for="temperaturyy">Temperatury</label>
</div>
<div class="form-check form-check-inline text-algin-left col-md-auto">
  <input class="form-check-input" type="radio" name="grupaWykres" id="avg" value="avg" v-model="checkradio">
  <label class="form-check-label" for="avg">Średnia temperatura</label>
</div>
<div class="form-check form-check-inline text-algin-left col-md-auto">
  <input class="form-check-input" type="radio" name="grupaWykres" id="minmax" value="minmax" v-model="checkradio">
  <label class="form-check-label" for="minmax">Minimalna i Maksymalna temperatura</label>
</div>
<div class="form-check form-check-inline text-algin-left col-md-auto">
  <input class="form-check-input" type="radio" name="grupaWykres" id="Grzanie" value="Grzanie" v-model="checkradio">
  <label class="form-check-label" for="Grzanie">Grzanie</label>
</div>
        </div>
      
    </div >
       <Temperatury v-if='checkradio=="temp"'/>
</template>
<script>
import Temperatury from './Temperatury.vue';
    export default {
    data() {
        return {
            checkradio: "none"
        };
    },
    components: { Temperatury }
}
</script>
<style>
.text-algin-left{
    text-align: left;
}

</style>