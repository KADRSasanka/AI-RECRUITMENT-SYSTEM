import { defineStore } from "pinia";
import { jwtDecode } from "jwt-decode";

export const useAuthStore = defineStore("auth", {

    state: () => ({
        token: localStorage.getItem("token"),
        user: JSON.parse(localStorage.getItem("user")) || null
    }),


    actions: {

        setToken(token) {

            this.token = token;

            const decoded = jwtDecode(token);

            this.user = decoded;


            localStorage.setItem(
                "token",
                token
            );


            localStorage.setItem(
                "user",
                JSON.stringify(decoded)
            );

        },


        logout() {

            this.token = null;

            this.user = null;


            localStorage.removeItem("token");

            localStorage.removeItem("user");

        },


        isAuthenticated() {

            return !!this.token;

        }

    }

});