<template>
  <div class="container-fluid">
    <div class="card-columns">
      <!-- <div class="col-12 mt-3 d-flex flex-row justify-content-center"> -->
      <Keep v-for="keep in keeps" :keepData="keep" v-if="keep.isPrivate == 1"></Keep>
      <!-- </div> -->
    </div>
  </div>
</template>

<script>
  import Keep from "@/components/Keep.vue"
  export default {
    name: "home",
    components: {
      Keep
    },
    data() {
      return {


      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },

    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch('getPublicKeeps');
    }
  };
</script>