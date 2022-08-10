export default {
    name: "RggWheel",
    data: function(){
        return{
            interval: 100,
            displayCount: 5,
            startSpeed: 30,
            started: null,
            duration: 10000,
            position: 0,
            items:[
                { name: "1. Battletoads"},
                { name: "2. Metal Mech"},
                { name: "3. Darkwing Duck"},
                { name: "4. Disney's DuckTales"},
                { name: "5. Double Dragon II"},
                { name: "6. Excitebike"},
                { name: "7. Blaster Master"},
                { name: "8. Nightmare on Elm Street, A"},
                { name: "9. Little Nemo"},
                { name: "10. Burai Fighter"},
                { name: "11. Castlevania"},
                { name: "12. Contra"},
                { name: "13. Battletoads & Double Dragon"},
                { name: "14. Guardian Legend, The"},
                { name: "15. Tiny Toon Adventures"},
            ]
        }
    },
    computed:{
        finished: function(){
            if (this.started){
                let millis = this.started.valueOf() + this.duration
                return new Date(millis)
            }

            return null
        },
        currentItems: function(){
            let rest = this.items.length - this.position - 1

            if (rest >=  5){
                return this.items.slice(this.position,this.position + this.displayCount)
            } else{
                let arr = this.items.slice(this.position, this.items.length)
                let lastPart = this.items.slice(0, this.displayCount - rest - 1)
                arr.push(...lastPart)
                return arr
            }
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
        },
        formula(millis){
            //x(t) = t * x0 + (1.0 - t) * x1
            //let startedMillis = this.started.valueOf() //0%
            let timePassed = millis - this.started.valueOf() //x
            let totalMillis = this.finished.valueOf() - this.started.valueOf() // 100%
            let currentSpeed = this.startSpeed - ((timePassed / totalMillis) * this.startSpeed)
            return currentSpeed
        }
    },
    mounted(){
        this.roll()
    }
}