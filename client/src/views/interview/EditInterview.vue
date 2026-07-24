<template>


<div class="max-w-3xl mx-auto">


<h1 class="text-3xl font-bold mb-8">

Edit Interview

</h1>



<form
@submit.prevent="save"

class="bg-gray-700 shadow rounded-xl p-8 space-y-5">



<input

v-model="form.interviewDate"

type="date"

class="border-3 p-3 rounded-lg w-full"

/>




<input

v-model="form.interviewTime"

type="time"

class="border-3 p-3 rounded-lg w-full"

/>




<select

v-model="form.status"

class="border-3 p-3 rounded-lg w-full">


<option>
Scheduled
</option>

<option>
Completed
</option>

<option>
Cancelled
</option>


</select>




<textarea

v-model="form.notes"

class="border-3 p-3 rounded-lg w-full">

</textarea>




<button

class="bg-green-700 text-white px-6 py-3 rounded-lg">

Update

</button>



</form>



</div>

</template>



<script setup>


import {ref,onMounted} from "vue";

import {useRoute,useRouter}
from "vue-router";


import {
getInterview,
updateInterview
}
from "../../api/interview";



const route=useRoute();

const router=useRouter();


const form=ref({});



const load=async()=>{


const response =
await getInterview(route.params.id);


form.value=response.data;


};



const save=async()=>{


await updateInterview(

route.params.id,

form.value

);


alert("Updated");


router.push("/recruiter/interviews");


};



onMounted(load);



</script>