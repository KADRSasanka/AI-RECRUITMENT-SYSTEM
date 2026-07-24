<template>

<div class="max-w-6xl mx-auto">


<div class="flex justify-between items-center mb-8">

<div>

<h1 class="text-3xl font-bold">
Applicants
</h1>

<p class="text-gray-500">
AI ranked candidates for this job
</p>

</div>

</div>




<div class="bg-white rounded-xl shadow overflow-hidden">


<table class="w-full">


<thead class="bg-gray-100">

<tr>

<th class="p-4 justify-center">
Candidate
</th>


<th>
Applied Date
</th>


<th>
Status
</th>


<th>
AI Score
</th>


<th>
Recommendation
</th>


<th>
Actions
</th>


</tr>

</thead>



<tbody>


<tr
v-for="application in applications"
:key="application.applicationId"
class="border-t">


<td class="p-4">

{{application.candidateName}}

</td>



<td>

{{formatDate(application.appliedDate)}}

</td>



<td>

<span
class="px-3 py-1 rounded-full bg-blue-100 text-blue-700">

{{application.status}}

</span>

</td>




<td>

<button
@click="loadAI(application)"
class="text-purple-600 font-semibold">

Analyze

</button>

<div
v-if="application.aiScore">

{{application.aiScore}} %

</div>


</td>





<td>

<span
v-if="application.recommendation"
class="text-green-600">

{{application.recommendation}}

</span>


</td>






<td>


<router-link

:to="`/recruiter/application/${application.applicationId}`"

class="text-blue-600">

Review

</router-link>


</td>


</tr>


</tbody>


</table>


</div>


</div>


</template>





<script setup>


import {
ref,
onMounted
}
from "vue";


import {
useRoute
}
from "vue-router";


import {
getApplicationsByJob
}
from "../../api/application";


import {
analyzeCandidate
}
from "../../api/ai";



const route = useRoute();



const applications =
ref([]);






const load = async()=>{


const response =
await getApplicationsByJob(
    route.params.id
);


applications.value =
response.data;


};






const loadAI = async(application)=>{


try{


const response =
await analyzeCandidate(

application.candidateId,

application.jobId

);



application.aiScore =
response.data.matchScore;



application.recommendation =
response.data.recommendation;



}

catch(error){

console.error(error);

}


};





const formatDate=(date)=>{

return new Date(date)
.toLocaleDateString();

};





onMounted(load);



</script>