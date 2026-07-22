<template>

<div>


<h1 class="text-3xl font-bold">
    Administrator Dashboard
</h1>


<p class="text-gray-500 mt-2">
    Manage users, jobs and recruitment activities
</p>



<div class="grid md:grid-cols-3 gap-6 mt-8">


<StatCard
title="Total Users"
:value="120"
/>


<StatCard
title="Active Jobs"
:value="45"
/>



<StatCard
title="Applications"
:value="230"
/>


</div>





<div class="grid md:grid-cols-2 gap-6 mt-8">


<div class="bg-white rounded-xl shadow p-6">


<h2 class="font-bold text-xl mb-4">
Recruitment Overview
</h2>


<div class="h-64 flex items-center justify-center text-gray-400">

Chart Area

</div>


</div>





<div class="bg-white rounded-xl shadow p-6">


<h2 class="font-bold text-xl mb-4">
Quick Actions
</h2>


<button>
<router-link
to="/admin/users"
class="block w-full bg-blue-600 text-white p-3 rounded-lg mb-3 text-center"
>

Manage Users

</router-link>
</button>



<button
class="block w-full bg-green-600 text-white p-3 rounded-lg">

Manage Jobs

</button>



</div>


</div>



</div>

</template>



<script setup>

import {ref,onMounted} from "vue";

import StatCard from "../../components/admin/StatCard.vue";

import {getDashboard}
from "../../api/dashboard";



const stats = ref({

    totalUsers:0,

    totalJobs:0,

    totalApplications:0

});



const loading = ref(true);

const error = ref("");





const loadDashboard = async()=>{


    try{


        const response = await getDashboard();


        console.log(
            "DASHBOARD DATA:",
            response.data
        );


        stats.value=response.data;


    }
    catch(err){


        console.log(
            "DASHBOARD ERROR:",
            err
        );


        error.value=
        "Unable to load dashboard";


    }
    finally{


        loading.value=false;


    }


}





onMounted(()=>{

    loadDashboard();

});


</script>