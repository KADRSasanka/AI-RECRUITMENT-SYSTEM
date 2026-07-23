<template>

<div>

<h1 class="text-3xl font-bold mb-6">
Manage Jobs
</h1>


<div class="flex justify-between mb-6">


<h2 class="text-xl">
Available Jobs
</h2>


<router-link
to="/recruiter/jobs/create"
class="bg-blue-600 text-white px-5 py-2 rounded-lg">

Create Job

</router-link>


</div>




<div class="bg-white rounded-xl shadow overflow-hidden">


<table class="w-full">


<thead class="bg-gray-100">

<tr>

<th class="p-4 justify-center">
Title
</th>


<th class="p-4 justify-center">
Location
</th>


<th class="p-4 justify-center">
Status
</th>


<th class="p-4 justify-center">
Actions
</th>


</tr>

</thead>



<tbody>


<tr
v-for="job in jobs"
:key="job.jobId"
class="border-t"
>


<td class="p-4">
{{job.jobTitle}}
</td>


<td class="p-4">
{{job.location}}
</td>


<td class="p-4">
{{job.status}}
</td>


<td class="p-4">

<button
@click="removeJob(job.jobId)"
class="bg-red-500 text-white px-3 py-1 rounded">

Delete

</button>

</td>


</tr>


</tbody>


</table>


</div>


</div>

</template>



<script setup>

import {ref,onMounted} from "vue";

import {
getJobs,
deleteJob
}
from "../../api/job";


const jobs = ref([]);



const loadJobs = async()=>{

const response =
await getJobs();


console.log(
"JOBS:",
response.data
);


jobs.value=response.data;


};



const removeJob = async(id)=>{


await deleteJob(id);


loadJobs();


};



onMounted(()=>{

loadJobs();

});


</script>