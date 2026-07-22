import { defineStore } from "pinia";
import { jwtDecode } from "jwt-decode";


export const useAuthStore = defineStore("auth", {

    state: () => ({
        token: localStorage.getItem("token"),
        user: JSON.parse(localStorage.getItem("user")) || null
    }),


    getters: {

        isAuthenticated: (state) =>
            !!state.token,


        role: (state)=>
            state.user?.role || null

    },


    actions:{


        login(data){

            this.token = data.token;


            const decoded = jwtDecode(data.token);


            this.user = {

                id:
                decoded.sub,


                name:
                data.fullName,


                email:
                data.email,


                role:
                data.role

            };


            localStorage.setItem(
                "token",
                this.token
            );


            localStorage.setItem(
                "user",
                JSON.stringify(this.user)
            );

        },



        logout(){

            this.token=null;

            this.user=null;


            localStorage.removeItem("token");

            localStorage.removeItem("user");


        }

    }


});