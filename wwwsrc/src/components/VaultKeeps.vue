<template>
  <div class="vaultKeep px-1 col-12 col-md-3 d-flex justify-content-center">
    <div class="card" style="width: 18rem;">
      <img :src="vaultKeepData.img" class="card-img-top" alt="..." max-height="30rem" max-width="30rem">
      <div class="card-body">
        <h5 class="card-title">{{vaultKeepData.name}}</h5>
        <p class="card-text">{{vaultKeepData.description}}</p>
        <p class="card-text"><i class="far fa-eye"></i>{{vaultKeepData.views}}</p>
        <p class="card-text"><i class="fas fa-lock"></i>{{vaultKeepData.keeps}}</p>
        <button class="btn btn-primary" @click="removeKeep(vaultKeepData.id)">Remove</button>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'Vaultkeeps',
    props: ['vaultKeepData'],
    data() {
      return {

      }
    },
    computed: {

    },
    methods: {
      removeKeep(keepId) {
        let payload = {
          keepId,
          vaultId: this.$route.params.vaultId
        }
        this.$store.dispatch('removeKeep', payload)
      }
    }
  }

</script>

<style>


</style>