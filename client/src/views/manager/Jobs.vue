<template>

<div class="max-w-6xl mx-auto">


<div class="mb-8">

<h1 class="text-3xl font-bold">
Assigned Jobs
</h1>

<p class="text-gray-500 mt-2">
Jobs assigned to you for recruitment review.
</p>

</div>



<div class="bg-white rounded-xl shadow overflow-hidden">


<table class="w-full">


<thead class="bg-gray-100">

<tr>

<th class="p-4 justify-center">
Job Title
</th>


<th>
Organization
</th>


<th>
Department
</th>


<th>
Recruiter
</th>


<th>
Status
</th>


<th>
Action
</th>


</tr>

</thead>



<tbody>


<tr
v-for="job in jobs"
:key="job.jobId"
class="border-t">


<td class="p-4 font-semibold">

{{job.jobTitle}}

</td>


<td>

{{job.organizationName}}

</td>


<td>

{{job.departmentName}}

</td>


<td>

{{job.recruiterName}}

</td>


<td>

<span
class="px-3 py-1 rounded-full bg-green-100 text-green-700">

{{job.isActive ? "Active":"Closed"}}

</span>

</td>


<td>

<router-link

:to="`/manager/applications?job=${job.jobId}`"

class="text-blue-600">

View Candidates

</router-link>


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
getManagerJobs
}
from "../../api/hiringManager";


const jobs=ref([]);



const load=async()=>{

const response =
await getManagerJobs();

jobs.value=response.data;

};



onMounted(load);


</script>