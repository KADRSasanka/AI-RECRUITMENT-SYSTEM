<template>

<div>

<div class="flex justify-between items-center mb-8">

<div>

<h1 class="text-3xl font-bold">

Applicants

</h1>

<p class="text-gray-500">

Candidates who applied for this position

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

Score

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

{{application.status}}

</td>

<td>

{{application.score ?? "-" }}

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

import {ref,onMounted} from "vue";

import {useRoute} from "vue-router";

import {getApplicationsByJob}
from "../../api/application";

const route=useRoute();

const applications=ref([]);

const load=async()=>{

const response=
await getApplicationsByJob(route.params.id);

applications.value=response.data;

};

const formatDate=(date)=>{

return new Date(date).toLocaleDateString();

};

onMounted(load);

</script>