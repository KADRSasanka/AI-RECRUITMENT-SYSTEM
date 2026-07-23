<template>

<div>


<h1 class="text-3xl font-bold mb-6">
User Management
</h1>


<div class="bg-white rounded-xl shadow overflow-hidden">


<table class="w-full">


<thead class="bg-gray-100">

<tr>

<th class="p-4 justify-center">
Name
</th>

<th class="p-4 justify-center">
Email
</th>


<th class="p-4 justify-center">
Role
</th>


<th class="p-4 justify-center">
Status
</th>


</tr>

</thead>



<tbody>


<tr
v-for="user in users"
:key="user.userId"
class="border-t"
>


<td class="p-4">
{{user.firstName}} {{user.lastName}}
</td>


<td class="p-4">
{{user.email}}
</td>


<td class="p-4">
{{user.role}}
</td>


<td class="p-4">

<span
class="px-3 py-1 rounded-full text-sm"
:class="
user.isActive
?'bg-green-100 text-green-700'
:'bg-red-100 text-red-700'
"
>

{{user.isActive ? "Active":"Inactive"}}

</span>


</td>


</tr>


</tbody>


</table>


</div>


</div>

</template>



<script setup>

import {ref,onMounted} from "vue";

import {getUsers}
from "../../api/user";


const users=ref([]);



const loadUsers=async()=>{


const response =
await getUsers();


console.log(
"USERS:",
response.data
);


users.value=response.data;


}



onMounted(()=>{

loadUsers();

});


</script>