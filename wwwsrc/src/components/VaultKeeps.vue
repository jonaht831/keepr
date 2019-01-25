<template>
  <div class="vaultKeep px-1 col-12 col-md-3 d-flex justify-content-center">
    <div class="card" style="width: 18rem;">
      <img :src="vaultKeepData.img" class="card-img-top" alt="..." max-height="30rem" max-width="30rem">
      <div class="card-body">
        <h5 class="card-title">{{vaultKeepData.name}}</h5>
        <p class="card-text">{{vaultKeepData.description}}</p>
        <p class="card-text"><i class="far fa-eye"></i>{{vaultKeepData.views}}</p>
        <p class="card-text"><i class="fas fa-lock"></i>{{vaultKeepData.keeps}}</p>
        <!-- Button trigger modal -->
        <div>
          <button type="button" class="mb-1 btn btn-info" @click="incrementViewed(vaultKeepData)" data-toggle="modal"
            data-target="#exampleModalCenter" :data-target="'#kMod' + vaultKeepData.id">
            View
          </button>
        </div>
        <button class="btn btn-primary" @click="removeKeep(vaultKeepData.id)">Remove</button>
      </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" :id="'kMod'+vaultKeepData.id" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalCenterTitle">{{vaultKeepData.name}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <img :src="vaultKeepData.img" class="card-img-top" alt="..." max-height="30rem" max-width="30rem">
            <p class="card-text">{{vaultKeepData.description}}</p>
            <div class="col d-flex justify-content-around">
              <p class="card-text"><i class="far fa-eye"></i>{{vaultKeepData.views}}</p>
              <p class="card-text" v-if="vaultKeepData.isPrivate == 0">Private</p>
              <p class="card-text"><i class="fas fa-lock"></i>{{vaultKeepData.keeps}}</p>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
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
          vaultId: this.$route.params.vaultId,
        }
        this.$store.dispatch('removeKeep', payload)
      },
      incrementViewed(keep) {
        this.$store.dispatch('incrementViewed', keep)
      }
    }
  }

</script>

<style>


</style>