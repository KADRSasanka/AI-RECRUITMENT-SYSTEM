<template>

<div>


<h1 class="text-3xl font-bold mb-6">
User Management
</h1>



<div class="bg-white rounded-xl shadow p-6">


<table class="w-full">


<thead>

<tr class="border-b">

<th class="text-left p-3">
Name
</th>

<th class="text-left p-3">
Email
</th>

<th class="text-left p-3">
Role
</th>

<th class="text-left p-3">
Status
</th>


</tr>

</thead>



<tbody>


<tr
v-for="user in users"
:key="user.userId"
class="border-b">


<td class="p-3">
{{user.firstName}} {{user.lastName}}
</td>


<td class="p-3">
{{user.email}}
</td>


<td class="p-3">
{{user.role?.name}}
</td>


<td class="p-3">

<span
class="bg-green-100 text-green-700 px-3 py-1 rounded">

Active

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

import {getUsers} from "../../api/user";


const users = ref([]);



const loadUsers = async()=>{


try{


const response = await getUsers();


users.value=response.data;


}
catch(error){

console.log(error);

}


};



onMounted(loadUsers);


</script>