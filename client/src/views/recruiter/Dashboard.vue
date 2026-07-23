<template>

<div>


<div class="mb-8">


<h1 class="text-3xl font-bold">

Recruiter Dashboard

</h1>


<p class="text-gray-500 mt-2">

Monitor vacancies, applications and hiring progress.

</p>


</div>





<div class="grid md:grid-cols-3 lg:grid-cols-4 gap-6">


<StatCard
title="Total Jobs"
:value="stats.totalJobs"
/>


<StatCard
title="Active Jobs"
:value="stats.activeJobs"
/>


<StatCard
title="Applications"
:value="stats.totalApplications"
/>


<StatCard
title="Pending Review"
:value="stats.pendingApplications"
/>


<StatCard
title="Interviews"
:value="stats.interviewScheduled"
/>


<StatCard
title="Hired"
:value="stats.hiredCandidates"
/>


</div>






<div class="grid md:grid-cols-2 gap-6 mt-10">


<div class="bg-gray-700 rounded-xl shadow p-6">


<h2 class="text-xl font-bold mb-4">

Recruitment Overview

</h2>



<div class="h-64 flex items-center justify-center text-gray-400">


Chart Area


</div>


</div>





<div class="bg-gray-700 rounded-xl shadow p-6">


<h2 class="text-xl font-bold mb-4">

Quick Actions

</h2>




<router-link
to="/recruiter/jobs/create"
class="block bg-blue-600 text-white p-3 rounded-lg mb-3 text-center">

Create New Job

</router-link>




<router-link
to="/recruiter/jobs"
class="block bg-green-600 text-white p-3 rounded-lg mb-3 text-center">

Manage Jobs

</router-link>




<router-link
to="/recruiter/applications"
class="block bg-blue-600 text-white px-5 py-3 rounded-lg">

Review Applications

</router-link>


</div>


</div>


</div>


</template>





<script setup>


import {ref,onMounted} from "vue";

//import StatCard from "../../components/admin/StatCard.vue";
import StatCard from "../../components/common/StatCard.vue";

import {getDashboard}
from "../../api/dashboard";



const stats=ref({

totalJobs:0,

activeJobs:0,

totalApplications:0,

pendingApplications:0,

interviewScheduled:0,

hiredCandidates:0

});




const loadDashboard=async()=>{


try{


const response=
await getDashboard();



console.log(
"RECRUITER DASHBOARD",
response.data
);



stats.value=response.data;



}

catch(error){

console.log(
"Dashboard error",
error
);


}


};




onMounted(()=>{

loadDashboard();

});


</script>