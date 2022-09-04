import ApiService from "@/services/api-service";

export default {
    name: "RggConsoles",
    data: function(){
        return{
            platforms: []
        }
    },
    mounted() {
        ApiService.get("/platform/list").then(response => {
            this.platforms = response.data
            console.log(this.platforms)
        })
    }
}