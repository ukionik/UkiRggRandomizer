<template>
  <div>
    <router-view></router-view>
  </div>
</template>

<script>

export default {
  name: 'App',
  beforeCreate() {
    document.body.className = "global"
  }
}
</script>

<style>
.global{
  background-color: #101010;
}

#app{
  flex-direction: column;
  font-family: Arial;
  display: flex;
  height: 100vh;
}
</style>
