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
              <input type="text" placeholder="Título" class="form-control" v-model="titulo">
            </p>
            <p>
              <input
                type="text"
                placeholder="Valor Total"
                class="form-control"
                v-model="valor_total"
              >
            </p>
            <p>
              <input
                type="text"
                placeholder="Qtd. Parcelas"
                class="form-control"
                v-model="qtd_parcelas"
              >
            </p>
            <p>
              <input type="text" placeholder="Juros %" class="form-control" v-model="juros">
            </p>
            <p>
              <input
                type="text"
                placeholder="Data da compra"
                class="form-control"
                v-model="vencimento_da_primeira_parcela"
              >
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
                <th role="columnheader" scope="col" aria-colindex="1" class>Parcela</th>
                <th role="columnheader" scope="col" aria-colindex="2" class>Valor</th>
                <th role="columnheader" scope="col" aria-colindex="3" class>Vencimento</th>
              </tr>
            </thead>
            <!---->
            <tbody role="rowgroup" class>
              <!---->
              <tr v-for="(parcela, index) in parcelasSimuladas" :key="index">
                <td>{{parcela.numeroDaParcela}}</td>
                <td>{{parcela.valor}}</td>
                <td>{{parcela.vencimento}}</td>
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
/* eslint-disable */

export default {
  data() {
    return {
      titulo: "",
      valor_total: null,
      qtd_parcelas: null,
      juros: null,
      data_da_compra: null,
      parcelasSimuladas: []
    };
  },
  methods: {
    simular() {
      //IMPLEMENTAR CÁLCULO DAS PARCELAS

      let _simul = {
        Valor: this.valor_total,
        QtdParcelas: this.qtd_parcelas,
        Juros: this.juros,
        DataDaCompra: this.data_da_compra
      };

      this.$http
        .post("http://localhost:5000/api/Simulation/simulate", _simul)        
        .then(async simulacao => this.parcelasSimuladas = await simulacao.json());
    }
  }
};
</script>

<style scoped>
</style>