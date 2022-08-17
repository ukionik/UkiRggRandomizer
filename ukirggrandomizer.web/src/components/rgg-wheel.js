import ApiService from "@/services/api-service";

export default {
    name: "RggWheel",
    data: function(){
        return{
            startMillis: null,
            nowMillis: null,
            interval: 8,
            displayCount: 5,
            schedule: null,
            duration: null
        }
    },
    computed:{
        rolling: function(){
            return this.startMillis && this.nowMillis < this.endMillis
        },
        endMillis: function(){
            if (this.startMillis){
                return this.startMillis + this.duration
            }

            return null
        },
        currentItems: function(){
            console.log((this.startMillis))
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
            ApiService.put("/wheel/simulate-wheel", {}).then(response => {
                let data = response.data
                this.schedule = data.schedule
                this.duration = data.realDuration
                this.startMillis = Date.now()
                this.startRoll(data.songPath)
            })
        },
        startRoll(songPath){
            ApiService.put("/wheel/roll",{
                songPath: songPath
            }).then(() => {
                console.log("Started")
            })
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
        setInterval(this.tick, this.interval)
    }
}