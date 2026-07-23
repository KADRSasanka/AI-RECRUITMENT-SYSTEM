<template>

<div>


<h1 class="text-3xl font-bold">
Hiring Manager Dashboard
</h1>


<p class="text-gray-400 mt-2">
Monitor recruitment activities and candidate progress.
</p>



<div class="grid md:grid-cols-3 gap-6 mt-8">


<div class="bg-gray-700 shadow rounded-xl p-6">

<h3 class="text-gray-300">
Assigned Jobs
</h3>

<p class="text-4xl font-bold">
{{jobs}}
</p>

</div>



<div class="bg-gray-700 shadow rounded-xl p-6">

<h3 class="text-gray-300">
Applications
</h3>

<p class="text-4xl font-bold">
{{applications}}
</p>

</div>



<div class="bg-gray-700 shadow rounded-xl p-6">

<h3 class="text-gray-300">
Interviews
</h3>

<p class="text-4xl font-bold">
{{interviews}}
</p>

</div>



</div>



</div>

</template>



<script setup>

import {ref,onMounted} from "vue";

import api from "../../api/axios";


const jobs=ref(0);
const applications=ref(0);
const interviews=ref(0);



const loadDashboard=async()=>{


const jobResponse =
await api.get("/HiringManager/jobs");


jobs.value =
jobResponse.data.length;



const appResponse =
await api.get("/HiringManager/applications");


applications.value =
appResponse.data.length;


};



onMounted(loadDashboard);


</script>