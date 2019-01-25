<template>
  <div class="container-fluid dashboard">
    <div class="card-columns">
      <Vaults v-for="vault in vaults" :vaultData="vault"></Vaults>
    </div>
    <div class="card-columns">
      <Keep v-for="keep in keeps" :keepData="keep"></Keep>
    </div>
  </div>
</template>

<script>
  import Keep from '@/components/Keep.vue'
  import Vaults from '@/components/Vaults.vue'
  export default {
    name: 'dashboard',
    components: {
      Vaults,
      Keep
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
      },
      keeps() {
        return this.$store.state.keeps || []
      }
    },
    methods: {

    }
  }

</script>

<style>


</style>