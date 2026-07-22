<template>

<div class="min-h-screen flex items-center justify-center bg-gray-100">


    <div class="bg-white p-8 rounded-xl shadow-lg w-96">


        <h1 class="text-3xl font-bold text-center mb-6">
            AI Recruitment System
        </h1>


        <form @submit.prevent="handleLogin">


            <div class="mb-4">

                <label class="block mb-2">
                    Email
                </label>


                <input
                    v-model="email"
                    type="email"
                    class="w-full border rounded-lg p-3"
                    placeholder="Enter email"
                />

            </div>



            <div class="mb-4">

                <label class="block mb-2">
                    Password
                </label>


                <input
                    v-model="password"
                    type="password"
                    class="w-full border rounded-lg p-3"
                    placeholder="Enter password"
                />

            </div>



            <button
                class="w-full bg-blue-600 text-white py-3 rounded-lg"
                :disabled="loading"
            >

                {{loading ? "Logging in..." : "Login"}}

            </button>


        </form>



        <p 
        v-if="error"
        class="text-red-500 mt-4 text-center">

            {{error}}

        </p>


    </div>


</div>

</template>



<script setup>

import { ref } from "vue";
import { useRouter } from "vue-router";
import { useAuthStore } from "../../stores/authStore";
import { login } from "../../api/auth";


const email = ref("");

const password = ref("");

const error = ref("");

const loading = ref(false);



const router = useRouter();

const auth = useAuthStore();



const handleLogin = async()=>{


    try{


        loading.value=true;

        error.value="";



        const response = await login({

            email: email.value,

            password: password.value

        });
        console.log("LOGIN RESPONSE:", response);



        const token = response.data.token;



        auth.setToken(token);



        const role = 
        auth.user.role || 
        auth.user[
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        ];



        switch(role){


            case "Administrator":

                router.push("/admin/dashboard");

                break;



            case "Recruiter":

                router.push("/recruiter/dashboard");

                break;



            case "HiringManager":

                router.push("/manager/dashboard");

                break;



            case "Candidate":

                router.push("/candidate/dashboard");

                break;



            default:

                router.push("/");

        }



    }
    catch(err){

        console.log("LOGIN ERROR:",err);

        error.value =
        err.response?.data?.message ||
        "Login failed";


    }
    finally{

        loading.value=false;

    }


}


</script>