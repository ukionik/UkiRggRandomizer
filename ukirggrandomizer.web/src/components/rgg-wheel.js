import ApiService from "@/services/api-service";

export default {
    name: "RggWheel",
    data: function(){
        return{
            interval: 5,
            displayCount: 5,
            items:{}
        }
    },
    computed:{
        currentItems: function(){
            /*let rest = this.items.length - this.position - 1

            if (rest >=  this.displayCount){
                return this.items.slice(this.position,this.position + this.displayCount)
            } else{
                let arr = this.items.slice(this.position, this.items.length)
                let lastPart = this.items.slice(0, this.displayCount - rest - 1)
                arr.push(...lastPart)
                return arr
            }*/

            if (!this.items){
                return []
            }

            return this.items.slice(0, this.displayCount)
        }
    },
    methods:{
        roll(){
            this.started = new Date()
            setInterval(this.tick, this.interval)
        },
        tick(){
            let nowMillis = Date.now()
            this.calculatePosition(nowMillis)
        },
        calculatePosition(millis){
            if (millis < this.finished.valueOf()){
                let timePassed = millis - this.started.valueOf()
                let currentSpeed = this.formula(millis)
                let newPosition = (currentSpeed * timePassed) / 1000
                this.position = Math.round(newPosition) % this.items.length
                console.log(`Item: ${this.position} Position: ${newPosition} Speed: ${currentSpeed}`)
            }
        }
    },
    mounted(){
        ApiService.get("/wheel/items").then(response => {
            this.items = {}
            response.data.forEach(item => {
                this.items[item.index] = item
            })

            console.log(this.items)
        })


        /*ApiService.get("/wheel/generate-schedule").then(response => {
            console.log(response.data)
        })*/
    }
}