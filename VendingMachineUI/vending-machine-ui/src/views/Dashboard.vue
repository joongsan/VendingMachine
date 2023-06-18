<template>
  <!-- Root template for the Dashboard -->
  <div>
    <!-- Render the VendingMachine component -->
    <VendingMachine />
  </div>
</template>

<script lang="ts">
// Import necessary dependencies
import { Component, Vue } from "vue-property-decorator";
import VendingMachine from "../components/VendingMachine.vue";

// Decorate the component with necessary configuration
@Component({
  components: {
    VendingMachine, // Register the VendingMachine component for use in the template
  },
})
export default class Dashboard extends Vue {} // Export the Dashboard component
</script>
