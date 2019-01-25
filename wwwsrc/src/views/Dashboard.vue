<template>
  <div class="container-fluid dashboard">
    <div class="row">
      <Vaults v-for="vault in vaults" :vaultData="vault"></Vaults>
    </div>
  </div>
</template>

<script>
  import Vaults from '@/components/Vaults.vue'
  export default {
    name: 'dashboard',
    components: {
      Vaults
    },
    data() {
      return {

      }
    },
    mounted() {
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults || []
      }
    },
    methods: {

    }
  }

</script>

<style>


</style>