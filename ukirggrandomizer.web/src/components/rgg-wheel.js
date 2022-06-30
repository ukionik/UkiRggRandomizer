export default {
    name: "RggWheel",
    data: function(){
        return{
            items:[
                { name: "Battletoads"},
                { name: "Metal Mech"},
                { name: "Darkwing Duck"},
                { name: "Disney's DuckTales"},
                { name: "Double Dragon II"},
                { name: "Excitebike"},
                { name: "Blaster Master"},
                { name: "Nightmare on Elm Street, A"},
                { name: "Little Nemo"},
                { name: "Burai Fighter"},
                { name: "Castlevania"},
                { name: "Contra"},
                { name: "Battletoads & Double Dragon"},
                { name: "Guardian Legend, The"},
                { name: "Tiny Toon Adventures"},
            ]
        }
    },
    computed:{
        currentItems: function(){
            return this.items.slice(0,5)
        }
    }
}