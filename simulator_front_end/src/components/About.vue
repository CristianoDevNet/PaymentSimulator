<template>
  <div>
    <b-row class="justify-content-md-center">
      <b-col col lg="10">
        <b-row>
          <h1>Sobre...</h1>
        </b-row>
      </b-col>
    </b-row>

    <b-row class="justify-content-md-center">
      <b-col col lg="5">
        <b-row>
          <b-container>
            <hr>
            <p class="lead">"Apesar de terem me ferido gravemente</p>
              <p class="lead">Em meio ao medo e ao pânico</p>
              <p class="lead">Vocês não me desertaram</p>
              <p class="lead">Meus companheiros de batalha"</p>
            </p>
          </b-container>
        </b-row>
      </b-col>
      <b-col col lg="5">
        <b-row>
          <b-embed
            type="iframe"
            aspect="16by9"
            src="https://www.youtube.com/embed/jhdFe3evXpk?rel=0"
            allowfullscreen
          ></b-embed>
        </b-row>
      </b-col>
    </b-row>
  </div>
</template>

<script>
export default {
  name: "About"
};
</script>

<style scoped>
</style>