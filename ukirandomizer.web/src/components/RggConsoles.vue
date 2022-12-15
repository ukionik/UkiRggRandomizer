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
      <h1 class="platform-full-name">{{ selectedPlatform.fullName }}</h1>
      <h1 class="platform-year">({{selectedPlatform.releaseYear}})</h1>
      <button type="button" class="start" @click="startRoll">START</button>
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
    flex: 2;
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
    border-left: 0.4rem solid #343435;
    padding: 2rem;
  }

  .selected-console .console-image-wrapper{

  }

  .selected-console h1{
    text-align: center;
    color: #fff;
    font-size: 2rem;
  }

  .selected-console .platform-full-name{
    margin-top: 1.5rem;
  }

  .selected-console .platform-year{
    margin-top: 0.5rem;
  }

  .selected-console img{
    height: 192px;
  }

  .start{
    color: #cacaca;

    border: 3px solid #23701c;
    background-color: #0a570a;
    border-radius: 0.5rem;
    cursor: pointer;
    margin-top: 2rem;
    font-size: 1.6rem;
    height: 4.5rem;
    width: 11rem;
  }

  .start:hover{
    color: #ececec;
    border: 3px solid #44d137;
    background: #2a912d;
  }

</style>