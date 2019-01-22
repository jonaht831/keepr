<template>
  <div class="vault px-1">
    <div class="card" style="width: 18rem;">
      <div class="card-body">
        <h5 class="card-title">{{vaultData.name}}</h5>
        <p class="card-text">{{vaultData.description}}</p>
        <a href="#" class="btn btn-primary">View</a>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Vault',
    props: ['vaultData'],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getVaults')
    },
    computed: {},
    methods: {}
  }

</script>

<style>


</style>