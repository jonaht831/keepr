<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" href="#">
        Keepr
      </a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown"
        aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavDropdown">
        <ul class="navbar-nav">
          <li class="nav-item">
            <a class="nav-link" href="/">Home</a>
          </li>
          <li v-if="!user.id" class="nav-item action">
            <router-link class="nav-link" :to="{name: 'login'}">Login/Register</router-link>
          </li>
          <li v-else class="nav-item action" @click="logout">
            <a class="nav-link hover">Logout</a>
          </li>
          <li class="nav-item action">
            <router-link class="nav-link" :to="{name: 'dashboard'}">Dash</router-link>
          </li>
        </ul>
      </div>
      <button v-if="user.id" type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#addVaultModal">
        Add a Vault
      </button>
      <button v-if="user.id" type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#addKeepModal">
        Add a Keep
      </button>
    </nav>
    <router-view />

    <!-- Modal -->
    <div class="modal fade" id="addKeepModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Let's add a Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="addKeep()">
              <div><input type="text" placeholder="Name" v-model="newKeep.name"></div>
              <div><input type="text" placeholder="Description" v-model="newKeep.description"></div>
              <div><input type="text" placeholder="Image Url" v-model="newKeep.img"></div>
              <div><input type="checkbox" v-model="newKeep.isPrivate">Private</div>
              <button type="submit" class="btn btn-primary">Add Keep</button>
            </form>
          </div>
        </div>
      </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="addVaultModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Let's add a Vault!</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="addVault()">
              <div><input type="text" placeholder="Name" v-model="newVault.name"></div>
              <div><input type="text" placeholder="Description" v-model="newVault.description"></div>
              <button type="submit" class="btn btn-primary">Add Vault</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          isPrivate: 0
        },
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('logout');
      },
      addKeep() {
        if (this.newKeep.isPrivate) {
          this.newKeep.isPrivate = 1
        } else {
          this.newKeep.isPrivate = 0
        }
        this.$store.dispatch('addKeep', this.newKeep);
      },
      addVault() {
        this.$store.dispatch('addVault', this.newVault);
      }
    }
  }
</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    background-image: linear-gradient(rgb(7, 8, 73), rgb(0, 195, 255));
    min-height: 100vh;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .hover {
    cursor: pointer;
  }
</style>