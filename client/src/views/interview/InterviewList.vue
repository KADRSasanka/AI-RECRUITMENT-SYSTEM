<template>

<div class="max-w-6xl mx-auto">


<div class="flex justify-between items-center mb-8">


<div>

<h1 class="text-3xl font-bold">
Interviews
</h1>

<p class="text-gray-500">
Manage scheduled interviews
</p>

</div>


<router-link
to="/recruiter/interviews/create"
class="bg-blue-600 text-white px-5 py-3 rounded-lg">

+ Schedule Interview

</router-link>


</div>




<div class="bg-white rounded-xl shadow overflow-hidden">


<table class="w-full">


<thead class="bg-gray-100">

<tr>

<th class="p-4 text-left">
Candidate
</th>


<th>
Job
</th>


<th>
Date
</th>


<th>
Type
</th>


<th>
Status
</th>


<th>
Actions
</th>


</tr>

</thead>



<tbody>


<tr
v-for="item in interviews"
:key="item.interviewId"
class="border-t">


<td class="p-4 py-6">

{{item.candidateName}}

</td>



<td>

{{item.jobTitle}}

</td>



<td>

{{formatDate(item.interviewDate)}}

</td>



<td>

{{item.interviewType}}

</td>



<td>

<span
class="px-3 py-1 rounded-full bg-blue-100 text-blue-700">

{{item.status}}

</span>

</td>



<td class="space-x-3">


<router-link

:to="`/recruiter/interviews/${item.interviewId}/edit`"

class="text-green-600">

Edit

</router-link>



<button
@click="remove(item.interviewId)"
class="text-red-600">

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
getInterviews,
deleteInterview
}
from "../../api/interview";


const interviews=ref([]);



const load=async()=>{

const response =
await getInterviews();

interviews.value=response.data;

};



const remove=async(id)=>{


if(confirm("Delete interview?")){


await deleteInterview(id);


load();


}


};



const formatDate=(date)=>{

return new Date(date)
.toLocaleDateString();

};



onMounted(load);


</script>