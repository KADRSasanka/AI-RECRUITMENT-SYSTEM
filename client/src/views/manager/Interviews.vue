<template>

<div>


<h1 class="text-3xl font-bold mb-8">
Interview Schedule
</h1>



<div class="bg-white rounded-xl shadow overflow-hidden">


<table class="w-full">


<thead class="bg-gray-100">

<tr>

<th class="p-4">
Candidate
</th>


<th>
Job
</th>


<th>
Date
</th>


<th>
Status
</th>


</tr>

</thead>



<tbody>


<tr
v-for="item in interviews"
:key="item.interviewId"
class="border-t">


<td class="p-4">

{{item.candidateName}}

</td>


<td>

{{item.jobTitle}}

</td>


<td>

{{formatDate(item.interviewDate)}}

</td>


<td>

{{item.status}}

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
getManagerInterviews
}
from "../../api/hiringManager";


const interviews=ref([]);



const load=async()=>{

const response =
await getManagerInterviews();


interviews.value=response.data;

};



const formatDate=(date)=>{

return new Date(date)
.toLocaleDateString();

};



onMounted(load);


</script>