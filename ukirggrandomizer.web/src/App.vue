<template>
  <button @click="roll" style="width: 100px">Roll</button>
  <RggWheel ref="rggWheel" />
</template>

<script>
import RggWheel from "@/components/RggWheel";

export default {
  name: 'App',
  components: {
    RggWheel
  },
  methods:{
    roll(){
      this.$refs.rggWheel.roll()
    }
  },
}
</script>

<style>
#app{
  flex-direction: column;
  font-family: Arial;
  display: flex;
  height: 100vh;
}
</style>
