<template>
    <div class="col-12 bc-purple py-3 my-2">
        <div>
            <h4>Forma Prezentacji</h4>
        </div>
        <div class="row px-5 justify-content-center">
            <div class="text-algin-left form-check form-check-inline col-md-auto">
                <input class="form-check-input" type="checkbox" id="Wykres" v-model="czyWykres" >
                <label class="form-check-label" for="inlineCheckbox1">Wykres</label>
            </div>
            <div class="text-algin-left form-check form-check-inline col-md-auto">
                <input class="form-check-input" type="checkbox" id="Tabela" v-model="czyTabela">
                <label class="form-check-label" for="Tabela">Tabela</label>
            </div>
            <div class="text-algin-left form-check form-check-inline col-md-auto">
                <input class="form-check-input" type="checkbox" id="alltime" v-model="czycalyokres" :checked="czycalyokres">
                <label class="form-check-label" for="alltime">Cały okres</label>
            </div>
        </div>
        <p v-if="error" class="my-2 text-white bg-danger font-weight-bold text-uppercase"> Nie udało sie pobrać danych o temperaturze</p>
        <div v-if="czyTabela" class="overflow-auto ">
            <table class="table text-white table-bordered table-hover">
  <thead>
    <tr>
      <th scope="col">Data i Godzina</th>
      <th scope="col">Temperatura Powietrza</th>
      <th scope="col">Temperatura Gleby</th>
      <th scope="col">Czy kabel grzewczy był włączony</th>
    </tr>
  </thead>
  <tr v-for="record in page" :key="record.id">
    <th scope="row">{{getSformatowanaData(record.dataPomiaru)}}</th>
    <td>{{record.temperaturaPowietrza}}&deg;C</td>
    <td>{{record.temperaturaGleby}}&deg;C</td>
    <td>{{record.czyGrzanieZalaczone?"Tak":"Nie"}}</td>
</tr>
  <tbody>
  </tbody>
</table>
<nav v-if="pageshowlist!=null" aria-label="pagination">
  <ul class="pagination justify-content-center">
    <li class="page-item" :class="{ disabled:pagenow==1}" @click="setpage(pagenow-1)">
      <span class="page-link">Poprzednia</span>
    </li>
    <li v-for="i in pageshowlist" class="page-item" :class="{ active: i== pagenow}" @click="setpage(i)">
      <span class="page-link">{{i}}</span>
    </li>
    <li class="page-item" :class="{disabled:pagenow==pageall}" @click="setpage(pagenow+1)">
      <span class="page-link" href="#">Następna</span>
    </li>
  </ul>
</nav>

        </div>
    </div>
</template>
<script>
    import moment from 'moment'
    import axios from 'axios'
export default{
    data(){
        return{
            czyTabela:false,
            czyWykres:false,
            dane:[],
            error:false,
            pagenow:1,
            pageshowlist:null,
            pageall:null,
            page:null,
            czycalyokres:true
        }
        
    },
    methods: {
    getTeperatury() {
        axios.get("https://palma.bieda.it/api/Palma/all").then(response=>{
     this.dane=response.data;
     this.getMaxPage();
     this.getpagelist();
     this.getPage(this.pagenow);
     

    }).catch(e => {
      console.log(e);
     this.error=true;
    })
    },
    getSformatowanaData(dataDoSformatowania){
      return moment(dataDoSformatowania).format("DD-MM-YYYY HH:mm:ss")

    },
    getPage(numerstrony){
      var startsplit = (numerstrony-1)*100;
      var stopsplit=startsplit+100
      console.log(this.dane)
      this.page=this.dane.slice(startsplit,stopsplit);
    },
    getMaxPage(){
      this.pageall=Math.ceil(this.dane.length/100)
    },
    getpagelist(){
      if(this.pagenow==1||this.pagenow==2){
        this.pageshowlist=5
      }
      if(this.pagenow>=this.pageall-3){
        this.pageshowlist=[this.pageall-4,this.pageall-3,this.pageall-2,this.pageall-1,this.pageall]
      }
      else{
        this.pageshowlist=[this.pagenow-2,this.pagenow-1,this.pagenow,this.pagenow+1,this.pagenow+2]
      }
    },
    setpage(page){
      if(page>0&&page<=this.pageall){
         this.pagenow=page;
      this.getPage(page);
      this.getpagelist();
      }
     
    }
  },
  mounted() {
    this.getTeperatury()
  }
}
   
</script>