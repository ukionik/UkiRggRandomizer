<template>
  <div class="console-panel">
    <div class="consoles">
      <div class="console" v-for="platform in platforms" :key="platform.id" @click="selectedPlatform = platform">
        <img :src="platform.imageUrl" />
        <h4>{{platform.shortName}}</h4>
      </div>
    </div>
    <div class="selected-console" v-if="selectedPlatform.id">
      <div class="console-image-wrapper">
        <img :src="selectedPlatform.imageUrl" />
      </div>
      <h1 class="platform-full-name">{{ selectedPlatform.fullName }} ({{selectedPlatform.releaseYear}})</h1>
    </div>
  </div>

</template>

<script src="./rgg-consoles.js"></script>

<style scoped>
  .console-panel{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
  }

  .consoles{
    display: flex;
    flex-wrap: wrap;
    flex: 1;
  }

  .console {
    padding: 2rem;
  }

  .console:hover{
    background-color: #52139d;
    cursor: pointer;
  }

  .console:hover h4{
    color: #ffad37;
    font-weight: bold;
  }

  .console img{
    height: 64px;
  }

  .console h4{
    text-align: center;
    margin-top: 8px;
    color: #fafafa;
  }

  .selected-console{
    display: flex;
    flex-direction: column;
    flex: 1;
    align-items: center;
    border-left: 0.5rem solid #005a10;
    padding: 2rem;
  }

  .selected-console .console-image-wrapper{

  }

  .selected-console .platform-full-name{
    margin-top: 1rem;
  }

  .selected-console img{
    height: 256px;
  }

  .selected-console h1{
    color: white;
    font-size: 2.5rem;
  }

</style>