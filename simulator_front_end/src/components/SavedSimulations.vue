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
              <a href="#" class="list-group-item list-group-item-action" @click.stop.prevent="itemSelecionado = index" v-bind:class="{ active: itemSelecionado == index }">
                <div class="d-flex w-100 justify-content-between">
                  <h5 class="mb-1">Em {{new Date(simulacao.dataDaCompra).toLocaleDateString("pr-BR")}}</h5>
                  <small>{{simulacao.quantidadeDeParcelas}} parcela(s)</small>
                </div>
                <p class="mb-1">{{simulacao.titulo}}</p>
              </a>
            </div>
          </b-container>
        </b-row>
      </b-col>
      <b-col col lg="5">
        <b-row>
          <b-container>

          </b-container>
        </b-row>
      </b-col>
    </b-row>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userId: 1,
      itemSelecionado: undefined,
      simulacoes: []
    };
  },
  methods: {
    mudar(){
      this.isActive = !this.isActive;
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