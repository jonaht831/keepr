<template>
  <div class="oneVault">
    <div class="container-fluid">
      <div class="row">
        <!-- <div class="col-12 mt-3 d-flex flex-row justify-content-center"> -->
        <VaultKeeps v-for="keep in vaultKeeps" :vaultKeepData="keep"></VaultKeeps>
        <!-- </div> -->
      </div>
    </div>

  </div>
</template>

<script>
  import VaultKeeps from '@/components/VaultKeeps.vue'
  export default {
    name: 'vault',
    components: {
      VaultKeeps
    },
    props: ['vaultId'],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getVaultKeeps', this.vaultId)
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }

    },
    methods: {}
  }

</script>

<style>


</style>