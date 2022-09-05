<template>
  <div class="consoles">
    <div class="console" v-for="platform in platforms" :key="platform.id">
      <img :src="platform.imageUrl" />
      <h4>{{platform.shortName}}</h4>
    </div>
  </div>
</template>

<script src="./rgg-consoles.js"></script>

<style scoped>
  .consoles{
    display: flex;
    flex-wrap: wrap;
  }

  .console {
    padding: 2rem;
  }

  .console img{
    height: 64px;
  }

  .console h4{
    text-align: center;
    margin-top: 8px;
    color: #fafafa;
  }
</style>