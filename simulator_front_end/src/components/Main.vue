<template>
  <div>
    <b-row class="justify-content-md-center">
      <b-col col lg="6">
        <Nav/>
      </b-col>
    </b-row>
    <hr>
    <b-container>
      <router-view></router-view>
    </b-container>
    <!-- <Nav/>
    <p>
      Lorem ipsum dolor sit amet consectetur adipisicing elit. Illum veniam dolorem quisquam, nesciunt mollitia consequuntur rem architecto facere qui eaque molestias ratione laboriosam cum aliquid laborum praesentium similique odio necessitatibus!
    </p>
    <router-view></router-view>-->
  </div>
</template>

<script>
import Nav from "./Nav";

export default {
  name: "Main",
  components: {
    Nav
  }
};
</script>

<style scoped>
.md-app {
  max-height: 400px;
  border: 1px solid rgba(#000, 0.12);
}

.md-drawer {
  width: 230px;
  max-width: calc(100vw - 125px);
}
</style>