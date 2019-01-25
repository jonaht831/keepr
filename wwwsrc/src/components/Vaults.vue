<template>
  <!-- <div class="vaults px-1 col-12 col-md-3 d-flex justify-content-center"> -->
  <div class="card" style="width: 18rem;">
    <div class="card-body">
      <h5 class="card-title">{{vaultData.name}}</h5>
      <p class="card-text">{{vaultData.description}}</p>
      <router-link class="btn btn-primary" :to="{name: 'vault', params: {vaultId: vaultData.id}}">View</router-link>
      <div>
        <button class="mt-1 btn btn-danger" @click="deleteVault(vaultData.id)">Delete</button>
      </div>
    </div>
  </div>
  <!-- </div> -->
</template>

<script>
  export default {
    name: 'Vaults',
    props: ['vaultData'],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getVaults')
    },
    computed: {},
    methods: {
      deleteVault(vaultId) {
        this.$store.dispatch('deleteVault', this.vaultData.id)
      }
    }
  }

</script>

<style>


</style>