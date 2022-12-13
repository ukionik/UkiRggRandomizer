import ApiService from "@/services/api-service";

export default {
    name: "RggConsoles",
    data: function(){
        return{
            platforms: [],
            selectedPlatform:{
                id: null,
                shortName: null,
                fullName: null,
                imageUrl: null,
                releaseYear: null
            }
        }
    },
    mounted() {
        ApiService.get("/platform/list").then(response => {
            this.platforms = response.data
            this.selectedPlatform = this.platforms[0]
        })
    }
}