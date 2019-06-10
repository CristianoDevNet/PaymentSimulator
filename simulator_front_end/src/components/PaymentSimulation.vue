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
        <b-row>Esquerda</b-row>
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
  name: "PaymentSimulation"
};
</script>

<style scoped>
</style>