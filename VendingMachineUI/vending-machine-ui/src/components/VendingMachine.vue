<template>
  <div v-if="vendingMachine">
    <h1>Vending Machine</h1>

    <div class="info-div">
      <div>
        Avaliable items: {{ vendingMachine.availableItems }}
      </div>
      <div>
        Current card holding amount: ${{ vendingMachine.cardAmount }} <br/>
        Current cash holding amount: ${{ vendingMachine.cashAmount }}
      </div>
    </div>
    <v-data-table
      :headers="headers"
      :items="transformItems(vendingMachine)"
      loading
      loading-test="Loading data please wait....."
      key="id" />
  </div>
</template>

<style scoped>
.info-div {
  display: flex;
  justify-content: space-between;
}
</style>

<script lang="ts">
import Vue from 'vue';
import axios from 'axios';
import { Component } from 'vue-property-decorator';

import IVendingMachine from '../domain/IVendingMachine';
import { Flavour } from '../domain/Flavour';

@Component
export default class VendingMachine extends Vue {
  headers = [
    { text: "Flavour", value: "flavour"},
    { text: "Price", value: "price"}
  ]

  vendingMachine: IVendingMachine | null = null;

  async mounted() {
    try {
      const response = await axios.get('https://localhost:7255/');

      this.vendingMachine = response.data;
    } catch (error) {
      console.log(error);
    }
  }

  transformItems(vendingMachine: IVendingMachine) {
    return vendingMachine?.items.map(x => ({
        id: x.id,
        price: "$" + x.price,
        flavour: this.mapFlavour(x.flavour)
      }));
  }

  mapFlavour(flavour: number): string {
    return Flavour[flavour];
  }
}
</script>