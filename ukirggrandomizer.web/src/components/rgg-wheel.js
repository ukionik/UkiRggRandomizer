import ApiService from "@/services/api-service";

export default {
    name: "RggWheel",
    data: function(){
        return{
            player: null,
            startMillis: null,
            nowMillis: null,
            interval: 5,
            displayCount: 5,
            schedule: null,
            durationSec: 40
        }
    },
    computed:{
        rolling: function(){
            return this.startMillis && this.nowMillis < this.endMillis
        },
        endMillis: function(){
            if (this.startMillis){
                return this.startMillis + this.durationSec * 1000
            }

            return null
        },
        currentItems: function(){
            let arr = []
            if (!this.schedule){
                for(let i = 0; i < this.displayCount; i++){
                    arr.push("---")
                }
            } else if (!this.rolling){
                let schedule = this.schedule[this.schedule.length - 1]

                schedule.previousItems.forEach(item => arr.push(`${item.index}. ${item.name}`))
                let currentItem = schedule.currentItem
                arr.push(`${currentItem.index}. ${currentItem.name}`)
                schedule.nextItems.map(item => arr.push(`${item.index}. ${item.name}`))
            } else{
                let millis = this.nowMillis - this.startMillis

                let schedule = this.schedule.find(s => {
                    return millis >= s.range.min && millis < s.range.max
                })

                if (!schedule){
                    schedule = this.schedule[this.schedule.length - 1]
                }

                schedule.previousItems.forEach(item => arr.push(`${item.index}. ${item.name}`))
                let currentItem = schedule.currentItem
                arr.push(`${currentItem.index}. ${currentItem.name}`)
                schedule.nextItems.map(item => arr.push(`${item.index}. ${item.name}`))
            }

            return arr
        }
    },
    methods:{
        roll(){
            this.startMillis = Date.now()
            this.player.play()
            setInterval(this.tick, this.interval)
        },
        tick(){
            if (this.startMillis){
                this.nowMillis = Date.now()
            } else{
                this.nowMillis = null
            }
        }
    },
    mounted(){
        this.player = document.getElementById("player")

        ApiService.put("/wheel/generate-schedule", {
            durationSec: this.durationSec
        }).then(response => {
            this.schedule = response.data
            this.roll()
        })

    }
}