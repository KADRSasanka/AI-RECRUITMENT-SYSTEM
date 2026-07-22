<template>

<div class="min-h-screen flex items-center justify-center bg-gray-100">


    <div class="bg-white p-8 rounded-xl shadow-lg w-96">


        <h1 class="text-3xl font-bold text-center mb-6">
            AI Recruitment System
        </h1>



        <form @submit.prevent="handleLogin">


            <div class="mb-4">

                <label class="block mb-2 font-medium">
                    Email
                </label>


                <input
                    v-model="email"
                    type="email"
                    class="w-full border rounded-lg p-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    placeholder="Enter email"
                    required
                />

            </div>





            <div class="mb-4">

                <label class="block mb-2 font-medium">
                    Password
                </label>


                <input
                    v-model="password"
                    type="password"
                    class="w-full border rounded-lg p-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    placeholder="Enter password"
                    required
                />

            </div>





            <button
                type="submit"
                class="w-full bg-blue-600 hover:bg-blue-700 text-white py-3 rounded-lg transition disabled:bg-gray-400"
                :disabled="loading"
            >

                {{ loading ? "Logging in..." : "Login" }}

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

import { useAuthStore } from "../../stores/auth";

import { login } from "../../api/auth";



const email = ref("");

const password = ref("");

const error = ref("");

const loading = ref(false);



const router = useRouter();

const auth = useAuthStore();





const handleLogin = async()=>{


    try{


        loading.value = true;

        error.value = "";



        if(!email.value || !password.value){

            error.value = "Please enter email and password";

            return;

        }




        const response = await login({

            email: email.value,

            password: password.value

        });



        console.log(
            "LOGIN RESPONSE:",
            response.data
        );



        /*
            response.data example:

            {
                token:"",
                fullName:"Admin User",
                email:"admin@email.com",
                role:"Administrator"
            }

        */



        auth.login(response.data);




        const role = response.data.role;



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



            case "Hiring Manager":

                router.push("/manager/dashboard");

                break;



            case "Candidate":

                router.push("/candidate/dashboard");

                break;



            default:


                console.log(
                    "Unknown Role:",
                    role
                );


                router.push("/login");


        }




    }
    catch(err){


        console.log(
            "LOGIN ERROR:",
            err
        );


        error.value =
            err.response?.data?.message ||
            "Invalid email or password";


    }
    finally{


        loading.value=false;


    }


}



</script>