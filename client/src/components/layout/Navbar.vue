<template>

<header 
class="bg-white shadow p-4 flex justify-between">


<h2 class="text-xl font-semibold">

Dashboard

</h2>



<div class="flex items-center gap-4">


<span>

{{userName}}

</span>



<button
@click="logout"
class="bg-red-500 text-white px-4 py-2 rounded">

Logout

</button>


</div>


</header>


</template>



<script setup>

import {computed} from "vue";

import {useRouter} from "vue-router";

import {useAuthStore} from "../../stores/auth";


const auth = useAuthStore();

const router = useRouter();



const userName = computed(()=>{


return auth.user?.name || "User";


});



const logout = ()=>{


auth.logout();


router.push("/login");


};


</script>