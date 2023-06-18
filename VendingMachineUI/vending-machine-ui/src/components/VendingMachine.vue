<template>
  <v-app>
    <div v-if="vendingMachine" class="content-div">
      <h1>Vending Machine</h1>

      <div class="info-div">
        <div>
          Available items: {{ vendingMachine.availableItems }}
        </div>
        <div>
          Current card holding amount: ${{ vendingMachine.cardAmount }} <br/>
          Current cash holding amount: ${{ vendingMachine.cashAmount }}
        </div>
      </div>

      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th class="text-left">
                Flavour
              </th>
              <th class="text-left">
                Price
              </th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="item in vendingMachine.items"
              :key="item.id"
            >
              <td>{{ mapFlavour(item.flavour) }}</td>
              <td>${{ item.price }}</td>
            </tr>
          </tbody>
        </template>
      </v-simple-table>

      <v-btn @click="showDialog = true">Select product</v-btn>

      <v-dialog 
        v-model="showDialog"
        persistent
        width="700px">
        <v-card>
          <v-card-title>
            <span>Please choose an item to purchase and payment method</span>
          </v-card-title>
          <v-form @submit.prevent="submitOrder">
            <v-card-text>
              <v-container>
                <v-row>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-select
                      :items="itemOptions"
                      label="Item*"
                      item-text="text"
                      item-value="value"
                      v-model="selectedItem.itemId"     
                      required />
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-select
                      :items="paymentOptions"
                      item-text="text"
                      item-value="value"
                      v-model="selectedItem.paymentType"   
                      label="Payment type*"
                      required />
                  </v-col>
                  <v-col>
                    <label>
                      Total amount of ${{ totalAmount }} <br/> will be charged.
                    </label>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-divider></v-divider>

            <v-card-actions> 
              <v-spacer></v-spacer>
              <v-btn
                color="primary"
                text
                @click="showDialog = false"
              >
                Cancel
              </v-btn>
              <v-btn
                :disabled="selectedItem.itemId === 0"
                color="primary"
                type="submit"
                text
              >
                Proceed
              </v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-dialog>
    </div>
  </v-app>
</template>

<style scoped>
.info-div {
  display: flex;
  justify-content: space-between;
}
.content-div {
  padding-left: 50px;
  padding-right: 50px;
}
</style>

<script lang="ts">
import Vue from 'vue';
import axios from 'axios';
import { Component, Watch } from 'vue-property-decorator';

import IVendingMachine from '../domain/IVendingMachine';
import { Flavour } from '../domain/Flavour';

const baseURL = 'https://localhost:7255/';

@Component
export default class VendingMachine extends Vue {
  headers = [
    { text: 'Flavour', value: 'flavour' },
    { text: 'Price', value: 'price' },
    { text: 'Select', value: '' },
  ];

  showDialog = false;

  vendingMachine: IVendingMachine | null = null;
  selectedItem: { itemId: number, paymentType: number } = { itemId: 0, paymentType: 0 }

  async mounted() {
    try {
      const response = await axios.get(baseURL);

      this.vendingMachine = response.data;
    } catch (error) {
      console.log(error);
    }
  }

  get itemOptions(): { text: string, value: number }[] {
    return (this.vendingMachine?.items.map(x => ({
        text: this.mapFlavour(x.flavour) + " " + "$" + x.price,
        value: x.id
    }))) || [];
  }

  get paymentOptions(): { text: string, value: number }[] {
    return [
      { text: "Card payment", value: 0 },
      { text: "Cash payment", value: 1 },
    ]
  }

  get totalAmount(): number {
    return this.vendingMachine?.items.find(x => x.id == this.selectedItem.itemId)?.price || 0;
  }

  closeDialog() {
    this.showDialog = false;
  }

  @Watch("showDialog")
  resetSelection() {
    if(!this.showDialog) {
      this.selectedItem.itemId = 0;
      this.selectedItem.paymentType = 0;
    }
  }

  mapFlavour(flavour: number): string {
    return Flavour[flavour];
  }
  
  async submitOrder() {
    // Perform the transaction with the selected item
    try {
      const response = await axios.post(baseURL, {
        currentVendingMachine: this.vendingMachine,
        itemId: this.selectedItem.itemId,
        paymentType: this.selectedItem.paymentType
      });

      this.vendingMachine = response.data;
    } catch (error) {
      console.log(error)
    } finally {
      // Reset the selection after the transaction is completed
      this.showDialog = false;
    }
  }
}
</script>
