<template>
    <div class="col-12 bc-purple py-3 my-2">
        <div>
            <h4>Forma Prezentacji</h4>
        </div>
        <div class="row px-5 justify-content-center">
            <div class="text-algin-left form-check form-check-inline col-md-auto">
                <input class="form-check-input" type="checkbox" id="Wykres" value="option1" >
                <label class="form-check-label" for="inlineCheckbox1">Wykres</label>
            </div>
            <div class="text-algin-left form-check form-check-inline col-md-auto">
                <input class="form-check-input" type="checkbox" id="Tabela" value="option1">
                <label class="form-check-label" for="Tabela">Tabela</label>
            </div>
        </div>
        <p v-if="error" class="my-2 text-white bg-danger font-weight-bold text-uppercase"> Nie udało sie pobrać danych o temperaturze</p>
        <div v-if="czyTabela">
            <table class="table text-white table-bordered table-hover">
  <thead>
    <tr>
      <th scope="col">Data i Godzina</th>
      <th scope="col">Temperatura Powietrza</th>
      <th scope="col">Temperatura Gleby</th>
      <th scope="col">Czy kabel grzewczy był włączony</th>
    </tr>
  </thead>
  <tr v-for="record in dane" :key="record.id">
    <th scope="row">{{record.dataPomiaru}}</th>
    <td>{{record.temperaturaPowietrza}}&deg;C</td>
    <td>{{record.temperaturaGleby}}&deg;C</td>
    <td>{{record.czyGrzanieZalaczone?"Tak":"Nie"}}</td>
</tr>
  <tbody>
  </tbody>
</table>
        </div>
    </div>
</template>
<script>
    import axios from 'axios'
export default{
    data(){
        return{
            czyTabela:true,
            czyWykres:false,
            dane:null,
            error:false
        }
        
    },
    methods: {
    getTeperatury() {
        axios.get("https://palma.bieda.it/api/Palma/all").then(response=>{
     this.dane=response.data;

    }).catch(e => {
     this.error=true;
    })
    }
  },
  mounted() {
    this.getTeperatury()
  }
}
   
</script>