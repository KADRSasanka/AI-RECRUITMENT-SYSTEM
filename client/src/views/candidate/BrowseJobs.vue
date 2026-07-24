<template>

<div class="max-w-6xl mx-auto">


<h1 class="text-3xl font-bold">
Browse Jobs
</h1>


<p class="text-gray-400 mt-2">
Find your next opportunity.
</p>



<div class="grid md:grid-cols-3 gap-6 mt-8">


<div
v-for="job in jobs"
:key="job.jobId"
class="bg-gray-700 rounded-xl p-6">


<h2 class="text-xl font-bold">

{{job.jobTitle}}

</h2>


<p class="text-gray-300 mt-2">

{{job.organizationName}}

</p>


<p class="mt-3">

{{job.location}}

</p>



<p class="mt-2">

{{job.employmentType}}

</p>



<router-link

:to="`/candidate/jobs/${job.jobId}`"

class="inline-block mt-5 bg-blue-600 px-5 py-2 rounded-lg">

View Job

</router-link>


</div>


</div>


</div>

</template>



<script setup>

import {ref,onMounted} from "vue";

import {
getJobs
}
from "../../api/job";


const jobs=ref([]);



const loadJobs=async()=>{


try{


const response =
await getJobs();


jobs.value =
response.data.filter(
job=>job.isActive
);


console.log(
"Jobs:",
response.data
);


}
catch(error){

console.error(error);

}


};



onMounted(loadJobs);


</script>