<template>

<div class="max-w-6xl mx-auto">


<h1 class="text-3xl font-bold mb-2">
Candidate Applications
</h1>


<p class="text-gray-500">
Review candidates applying for your assigned jobs.
</p>



<div class="bg-white rounded-xl mt-8 shadow overflow-hidden">


<table class="w-full">


<thead class="bg-gray-100">

<tr>

<th class="p-4 justify-center">
Candidate
</th>


<th>
Job
</th>


<th>
AI Score
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
v-for="item in applications"
:key="item.applicationId"
class="border-t">


<td class="p-4">

{{item.candidateName}}

</td>


<td>

{{item.jobTitle}}

</td>


<td>

{{item.score ?? "-"}}

</td>


<td>

{{item.status}}

</td>


<td>


<button
@click="open(item.applicationId)"
class="text-blue-600">

Review

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

import {useRouter} from "vue-router";


import {
getManagerApplications
}
from "../../api/hiringManager";


const router=useRouter();


const applications=ref([]);



const load=async()=>{

const response =
await getManagerApplications();


applications.value=response.data;

};



const open=(id)=>{

router.push(
`/manager/application/${id}`
);

};



onMounted(load);


</script>