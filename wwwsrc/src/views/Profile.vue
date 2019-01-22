<template>
  <div class="profile">
    <div class="row">
      <div class="col-12 d-flex flex-row justify-content-center">
        <Vault v-for="vault in vaults" :vaultData="vault"></Vault>
      </div>
    </div>
  </div>
</template>

<script>
  import Vault from '@/components/Vault.vue'
  export default {
    name: 'profile',
    components: {
      Vault
    },
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getVaults')
    },
    computed: {
      vaults() {
        return this.$store.state.vaults || []
      }
    },
    methods: {}
  }

</script>

<style>


</style>