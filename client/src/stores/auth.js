import { defineStore } from "pinia";
import { jwtDecode } from "jwt-decode";


export const useAuthStore = defineStore("auth", {


    state:()=>({

        token: localStorage.getItem("token"),

        user:
        JSON.parse(
            localStorage.getItem("user")
        ) || null

    }),



    getters:{


        isAuthenticated:(state)=>
            !!state.token,



        role:(state)=>
            state.user?.role || null


    },



    actions:{


        setToken(token, data){


            this.token = token;


            const decoded = jwtDecode(token);



            this.user={


                id:
                decoded.sub,


                name:
                data?.fullName || 
                decoded.name,



                email:
                data?.email ||
                decoded.email,



                role:
                data?.role ||
                decoded[
                "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                ]

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