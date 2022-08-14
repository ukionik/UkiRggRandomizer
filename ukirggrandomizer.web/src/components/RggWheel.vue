<template>
  <div class="wheel">
    <div v-for="item in currentItems" :key="item" class="wheel-item">
      {{ item }}
    </div>
    <audio id="player" src="http://localhost:18234/resources/sounds/retro/roll/Battletoads NES Music  Rat Race.mp3">
    </audio>
  </div>
</template>

<script src="./rgg-wheel.js"></script>

<style scoped>
.wheel {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-around;
  background-color: #161616;
  width: 100vw;
}

.wheel-item {
  color: #d8d8d8;
}

.wheel-item:nth-child(3) {
  font-size: 8vh;
}

.wheel-item:nth-child(2),
.wheel-item:nth-child(4) {
  font-size: 5vh;
}

.wheel-item:nth-child(1),
.wheel-item:nth-child(5) {
  font-size: 2vh;
}
</style>