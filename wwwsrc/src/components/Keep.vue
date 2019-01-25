<template>
  <div class="Keep col-12 col-md-3 d-flex justify-content-center">
    <div class="card" style="width: 18rem;">
      <img :src="keepData.img" class="card-img-top" alt="..." max-height="30rem" max-width="30rem">
      <div class="card-body">
        <h5 class="card-title">{{keepData.name}}</h5>
        <p class="card-text">{{keepData.description}}</p>
        <div class="col d-flex justify-content-around">
          <p class="card-text"><i class="far fa-eye"></i>{{keepData.views}}</p>
          <p class="card-text" v-if="keepData.isPrivate == 0">Private</p>
          <p class="card-text"><i class="fas fa-lock"></i>{{keepData.keeps}}</p>
        </div>
        <!-- Button trigger modal -->
        <button type="button" class="mb-1 btn btn-info" @click="incrementViewed(keepData)" data-toggle="modal"
          data-target="#exampleModalCenter" :data-target="'#kMod' + keepData.id">
          View
        </button>
        <div class="dropdown">
          <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Keep
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <p v-for="vault in vaults" class="dropdown-item hover" href="#" @click="saveKeepToVault(vault.id)">{{vault.name}}</p>
          </div>
        </div>
        <button class="mt-1 btn btn-primary" @click="deleteKeep(keepData.id)">Delete</button>
      </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" :id="'kMod'+keepData.id" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalCenterTitle">{{keepData.name}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <img :src="keepData.img" class="card-img-top" alt="..." max-height="30rem" max-width="30rem">
            <p class="card-text">{{keepData.description}}</p>
            <div class="col d-flex justify-content-around">
              <p class="card-text"><i class="far fa-eye"></i>{{keepData.views}}</p>
              <p class="card-text" v-if="keepData.isPrivate == 0">Private</p>
              <p class="card-text"><i class="fas fa-lock"></i>{{keepData.keeps}}</p>
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
    name: 'Keep',
    props: ['keepData'],
    data() {
      return {

      }
    },
    mounted() {

    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      saveKeepToVault(vaultId) {
        let payload = {
          vaultId,
          keepId: this.keepData.id,
          data: this.keepData
        }
        this.$store.dispatch('saveKeepToVault', payload)
      },
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId)
      },
      incrementViewed(keep) {
        this.$store.dispatch('incrementViewed', keep)
      }
    }
  }

</script>

<style>
  .card {
    border-radius: 25px;
    color: black;
    border-color: black;
    background-color: rgba(239, 243, 245, 0.993)
  }

  .card-text {
    color: black;
  }

  .card-img-top {
    border-top-right-radius: 25px;
    border-top-left-radius: 25px;
  }

  .hover {
    cursor: pointer;
  }
</style>