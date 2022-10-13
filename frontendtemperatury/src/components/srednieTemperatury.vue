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
        </div>
        <div v-if="czyTabela || czyWykres" class="row px-5 justify-content-center">
            <div class="text-algin-left form-check form-check-inline col-md-auto">
                <input class="form-check-input" type="checkbox" id="alltime" v-model="czycalyokres" :checked="czycalyokres">
                <label class="form-check-label" for="alltime">Cały okres</label>
            </div>
            <div v-if="!czycalyokres" class="col-md-auto p-0 d-flex flex-wrap">
              <div class="col-12 col-md-auto mx-1 form-group form-inline"> 
              
              <DatePicker id="od" v-model="od" mode="date" is24hr class="justify-content-start d-flex">
                <template v-slot="{ inputValue, inputEvents }">
                  <label for="od">Podaj date początkową:</label>
                  <input class="ms-1 border rounded focus:outline-none focus:border-blue-300" :value="inputValue" v-on="inputEvents" />
                </template>
              </DatePicker>
            </div>
            <div class="col-12 col-md-auto form-group form-inline">
                 
              <DatePicker id="do" v-model="dodate" mode="date" is24hr class="justify-content-start d-flex">
                <template v-slot="{ inputValue, inputEvents }">
                  <label for="od">Podaj date końcową:</label>
                  <input class="ms-1 border rounded focus:outline-none focus:border-blue-300" :value="inputValue" v-on="inputEvents" />
                </template>
              </DatePicker>
            </div>
            <div class="col-12 col-md-auto form-group form-inline ms-1 justify-content-start">
              <button type="button" class="btn btn-light" @click="getTeperaturyBetween()">Filtruj</button>
            </div>
            

            </div>
        </div>
        <p v-if="error" class="my-2 text-white bg-danger font-weight-bold text-uppercase"> Nie udało sie pobrać danych o temperaturze</p>
        <div v-if="czyTabela" class="overflow-auto pt-2">
            <table class="table text-white table-bordered table-hover">
  <thead>
    <tr>
      <th scope="col">Data</th>
      <th scope="col">Średnia Temperatura Powietrza</th>
      <th scope="col">Średnia Temperatura Gleby</th>
    </tr>
  </thead>
  <tr v-for="record in page" :key="record.id">
    <th scope="row">{{record.dataPomiaru}}</th>
    <td>{{record.sredniaPowietrza}}&deg;C</td>
    <td>{{record.sredniaGleby}}&deg;C</td>
</tr>
  <tbody>
  </tbody>
</table>
<nav v-if="pageshowlist!=null" aria-label="pagination">
  <ul class="pagination justify-content-center">
    <li class="page-item" :class="{ disabled:pagenow==1}" @click="setpage(pagenow-1)">
      <span class="page-link">&laquo;</span>
    </li>
    <li v-for="i in pageshowlist" class="page-item" :class="{ active: i== pagenow}" @click="setpage(i)">
      <span class="page-link">{{i}}</span>
    </li>
    <li class="page-item" :class="{disabled:pagenow==pageall}" @click="setpage(pagenow+1)">
      <span class="page-link" href="#">&raquo;</span>
    </li>
  </ul>
</nav>

        </div>
        <div v-if="czyWykres && readychart">
          <Wykres :labelsprops="labels" :datasetsprops="datasets"/>
        </div>
    </div>
</template>
<script>
    import moment from 'moment'
    import Wykres from './wykres.vue';
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
            czycalyokres:true,
            od: new Date(),
            dodate: new Date(),
            all:null,
            labels:[],
            datasets:[],
            readychart:false
        }
        
    },
    methods: {
    getTeperatury() {
      this.$axios.get("https://palma.bieda.it/api/Palma/srednia").then(response=>{
     this.dane=response.data;
     this.getMaxPage();
     this.getpagelist();
     this.getPage(this.pagenow);
     this.all=true     

    }).catch(e => {
     this.error=true;
    })
    },
    getTeperaturyBetween(){
      this.$axios.get("https://palma.bieda.it/api/Palma/srednia/between?startdate="+moment(this.od).format("YYYY-MM-DDTHH:mm:ss")+"&enddate="+moment(this.dodate).format("YYYY-MM-DDTHH:mm:ss")).then(response=>{
     this.dane=response.data;
     this.getMaxPage();
     this.getpagelist();
     this.getPage(this.pagenow);
     this.convertTochart()
     this.all=false   

    }).catch(e => {
     this.error=true;
    })
    },
    getPage(numerstrony){
      var startsplit = (numerstrony-1)*100;
      var stopsplit=startsplit+100
      this.page=this.dane.slice(startsplit,stopsplit);
    },
    async getMaxPage(){

       this.pagenow=1
      this.pageall=Math.ceil(this.dane.length/100)
    },
    getpagelist(){
      if(this.pageall<=5){
        this.pageshowlist=this.pageall
      }else{
        if(this.pagenow==1||this.pagenow==2){
        this.pageshowlist=5
      }else if(this.pagenow>=this.pageall-3){
        this.pageshowlist=[this.pageall-4,this.pageall-3,this.pageall-2,this.pageall-1,this.pageall]
      }
      else{
        this.pageshowlist=[this.pagenow-2,this.pagenow-1,this.pagenow,this.pagenow+1,this.pagenow+2]
      }
      }
      
    },
    setpage(page){
      if(page>0&&page<=this.pageall){
         this.pagenow=page;
      this.getPage(page);
      this.getpagelist();
      }
     
    },
  async convertTochart(){
          var temperaturaPowietrza2=[];
          var temperaturaGleby2=[];
          var labels2=[];
          this.dane.forEach(function(d){
            temperaturaPowietrza2.unshift(d.sredniaPowietrza);
            temperaturaGleby2.unshift(d.sredniaGleby);
            labels2.unshift(d.dataPomiaru);
          })
          this.labels=labels2
          this.datasets=[
            {
            label: 'Średnia Temperatura Powietrza',
            data: temperaturaPowietrza2,
            borderColor: '#00CCFF',
            backgroundColor:'#00CCFF',
          },
          {
            label: 'Średnia Temperatura Gleby',
            data: temperaturaGleby2,
            borderColor: '#DA7C20',
            backgroundColor:'#DA7C20'
          }]
          this.readychart=true
        },
    },
  mounted() {
    this.getTeperatury()
  },
  watch:{
    czycalyokres(newvalue,oldvalue){
      if(newvalue&&!this.all){
        this.getTeperatury()
        if(this.czyWykres){
          this.convertTochart()
        }
        
      }
      
    },
    czyWykres(newvalue,oldvalue){
          if(newvalue){
            this.convertTochart();
          }
        }
      },

  components:{
    Wykres
  }
  
}
   
</script>