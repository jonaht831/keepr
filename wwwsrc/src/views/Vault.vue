<template>
  <div class="oneVault">
    <div class="container-fluid">
      <div class="card-columns">
        <VaultKeeps v-for="keep in vaultKeeps" :vaultKeepData="keep"></VaultKeeps>
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