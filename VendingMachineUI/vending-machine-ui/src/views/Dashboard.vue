<template>
  <div>
    <VendingMachine />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import VendingMachine from "../components/VendingMachine.vue";

@Component({
  components: {
    VendingMachine,
  },
})
export default class Dashboard extends Vue {}
</script>
