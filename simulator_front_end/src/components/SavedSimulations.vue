<template>
  <div>
    <b-row class="justify-content-md-center">
      <b-col col lg="10">
        <b-row>
          <h1>Simulações Salvas</h1>
        </b-row>
      </b-col>
    </b-row>

    <b-row class="justify-content-md-center">
      <b-col col lg="5">
        <b-row>
          <b-container>
            <hr>
            <!-- <div class="list-group" v-for="(simulacao, index) in simulacoes" :key="index">              
              <a href="#" class="list-group-item list-group-item-action">{{simulacao.titulo}}</a>
            </div>-->
            <div class="list-group" v-for="(simulacao, index) in simulacoes" :key="index">
              <a
                href="#"
                class="list-group-item list-group-item-action"
                @click.stop.prevent="[itemSelecionado = index, simulacaoSelecionada = simulacao, carregarParcelas()]"
                v-bind:class="{ active: itemSelecionado == index }">
                <div class="d-flex w-100 justify-content-between">
                  <h5 class="mb-1">{{formatarParaMoedaBrasileira(simulacao.valorDaCompra)}}</h5>
                  <small>{{simulacao.quantidadeDeParcelas}} parcela(s)</small>
                </div>
                <p class="mb-1">{{simulacao.titulo}}</p>
                <br>
                <span
                  class="badge badge-pill badge-light"
                >Juros: {{simulacao.juros.toLocaleString('pt-BR')}} %</span>
                <span
                  class="badge badge-pill badge-light"
                >Simulado para: {{new Date(simulacao.dataDaCompra).toLocaleDateString("pr-BR")}}</span>
                <cite></cite>
              </a>
            </div>
          </b-container>
        </b-row>
      </b-col>
      <b-col col lg="5">
        <b-row>
          <b-container>
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
                <tr v-for="(parcela, index) in parcelas" :key="index">
                  <td>{{parcela.numeroDaParcela}}</td>
                  <td>{{parcela.valor}}</td>
                  <td>{{parcela.vencimento}}</td>
                </tr>
                <!---->
                <!---->
              </tbody>
              <tfoot>
                <tr>
                  <td colspan="3">Total: {{formatarParaMoedaBrasileira(valorTotalComJuros)}}</td>
                </tr>
              </tfoot>
            </table>
          </b-container>
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
      userId: 1,
      itemSelecionado: undefined,
      simulacaoSelecionada: {},
      simulacoes: [],
      parcelas: [],
      valorTotalComJuros: 0
    };
  },
  methods: {
    mudar() {
      this.isActive = !this.isActive;
    },
    carregarParcelas() {
      this.$http
        .post(
          "http://localhost:5000/api/Simulation/simulate",
          this.simulacaoSelecionada
        )
        .then(async simulacao => (this.parcelas = await simulacao.json()))
        .then(() => {
          let valorTotal = 0;

          this.parcelas.forEach(parcela => {
            valorTotal += parcela.valor;
          });

          this.valorTotalComJuros = valorTotal;
        });
    },
    formatarParaMoedaBrasileira(valor) {
      return valor.toLocaleString("pt-BR", {
        style: "currency",
        currency: "BRL",
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
      });
    }
  },
  created() {
    this.$http
      .get(`http://localhost:5000/api/Simulation/${this.userId}`)
      .then(async retorno => (this.simulacoes = await retorno.json()));
  }
};
</script>

<style scoped>
</style>