<template>
  <div>
    <b-row class="justify-content-md-center">
      <b-col col lg="10">
        <b-row>
          <h1>Simulação de Pagamento</h1>
        </b-row>
      </b-col>
    </b-row>

    <b-row class="justify-content-md-center">
      <b-col col lg="5">
        <b-row>
          <b-container>
            <hr>
            <p>
              <input type="text" placeholder="Título" class="form-control" v-model="Title">
            </p>
            <p>
              <input type="text" placeholder="Valor Total" class="form-control" v-model="Value">
            </p>
            <p>
              <input type="text" placeholder="Qtd. Parcelas" class="form-control" v-model="QtdParcelas">
            </p>
            <p>
              <input type="text" placeholder="Juros" class="form-control" v-model="juros">
            </p>
            <p>
              <button @click="simular()" class="btn btn-primary">Simular</button>
            </p>
          </b-container>
        </b-row>
      </b-col>
      <b-col col lg="5">
        <b-row>
          <table class="table b-table mt-3 border">
            <!---->
            <!---->
            <thead role="rowgroup" class>
              <!---->
              <tr role="row">
                <th role="columnheader" scope="col" aria-colindex="1" class>First Name</th>
                <th role="columnheader" scope="col" aria-colindex="2" class>Last Name</th>
                <th role="columnheader" scope="col" aria-colindex="3" class>Age</th>
              </tr>
            </thead>
            <!---->
            <tbody role="rowgroup" class>
              <!---->
              <tr role="row" class>
                <td role="cell" aria-colindex="1" class>Dickerson</td>
                <td role="cell" aria-colindex="2" class>MacDonald</td>
                <td role="cell" aria-colindex="3" class>40</td>
              </tr>
              <tr role="row" class>
                <td role="cell" aria-colindex="1" class>Larsen</td>
                <td role="cell" aria-colindex="2" class>Shaw</td>
                <td role="cell" aria-colindex="3" class>21</td>
              </tr>
              <tr role="row" class>
                <td role="cell" aria-colindex="1" class>Geneva</td>
                <td role="cell" aria-colindex="2" class>Wilson</td>
                <td role="cell" aria-colindex="3" class>89</td>
              </tr>
              <tr role="row" class>
                <td role="cell" aria-colindex="1" class>Jami</td>
                <td role="cell" aria-colindex="2" class>Carney</td>
                <td role="cell" aria-colindex="3" class>38</td>
              </tr>
              <!---->
              <!---->
            </tbody>
          </table>
        </b-row>
      </b-col>
    </b-row>
  </div>
</template>

<script>
export default {
  data() {
    return {
      titulo: "",
      valor_total: null,
      qtd_parcelas: null,
      juros: null,
      parcelasSimuladas: []
    }
  },
  methods: {
    simular() {

      let _simul = {
        Title: this.titulo,
        Valor: this.valor_total,
        QtdParcelas: this.qtd_parcelas,
        Juros: this.juros
      };

      this.$http
        .post("http://localhost:5000/api/Simulation/simulate", _simul)
        .then(async simulacao => {
          this.parcelasSimuladas.push(await simulacao.json());
          
        });
    }
  }
};
</script>

<style scoped>
</style>