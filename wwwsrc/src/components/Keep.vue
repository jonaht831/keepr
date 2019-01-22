<template>
  <div class="Keep px-1">
    <div class="card" style="width: 18rem;">
      <img :src="keepData.img" class="card-img-top" alt="..." max-height="30rem" max-width="30rem">
      <div class="card-body">
        <h5 class="card-title">{{keepData.name}}</h5>
        <p class="card-text">{{keepData.description}}</p>
        <p class="card-text"><i class="far fa-eye"></i>{{keepData.views}}</p>
        <p class="card-text"><i class="fas fa-lock"></i>{{keepData.keeps}}</p>
        <a href="#" class="btn btn-primary">KeeP</a>
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
    computed: {},
    methods: {}
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
</style>