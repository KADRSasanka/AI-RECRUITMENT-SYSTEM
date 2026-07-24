<template>

<div>


<h1 class="text-3xl font-bold">
My Applications
</h1>



<div class="bg-gray-700 rounded-xl mt-8 overflow-hidden">


<table class="w-full">


<thead>

<tr class="border-b">

<th class="p-4 text-left">
Job
</th>


<th>
Status
</th>


<th>
Score
</th>


</tr>

</thead>



<tbody>


<tr
v-for="item in applications"
:key="item.applicationId"
class="border-b">


<td class="p-4">

{{item.jobTitle}}

</td>


<td>

{{item.status}}

</td>


<td>

{{item.score ?? "-"}}

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
getApplicationsByCandidate
}
from "../../api/application";


const applications=ref([]);




const load=async()=>{


const candidateId =
localStorage.getItem("userId");


const response =
await getApplicationsByCandidate(
candidateId
);


applications.value =
response.data;


};




onMounted(load);


</script>