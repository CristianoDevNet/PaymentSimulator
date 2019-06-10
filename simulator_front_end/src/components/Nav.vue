<template>
  <div>
    <b-navbar type="light" variant="light">
      <b-navbar-nav>
        <router-link to="/PaymentSimulation" tag="b-nav-item">Simulação de Pagamento</router-link>
        <router-link to="/SavedSimulations" tag="b-nav-item">Simulações Salvas</router-link>
        <router-link to="/About" tag="b-nav-item">Sobre</router-link>        
      </b-navbar-nav>
    </b-navbar>
  </div>
</template>
<script>
export default {
  name: "Nav"
};
</script>

<style scoped>
</style>