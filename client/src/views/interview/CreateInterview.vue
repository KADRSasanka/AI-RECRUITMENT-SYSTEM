<template>

<div class="max-w-4xl mx-auto">


<h1 class="text-3xl font-bold mb-8">
Schedule Interview
</h1>



<form
@submit.prevent="submitInterview"
class="space-y-6">



<div class="bg-gray-700 shadow rounded-xl p-6">


<h2 class="text-xl font-bold mb-5 uppercase">
Application Details
</h2>


<div class="grid md:grid-cols-2 gap-5">


<div>

<label>
Candidate
</label>

<input
v-model="form.candidateName"
readonly
class="w-full border-3 p-3 rounded-lg bg-gray-700"
/>

</div>




<div>

<label>
Job
</label>

<input
v-model="form.jobTitle"
readonly
class="w-full border-3 p-3 rounded-lg bg-gray-700"
/>

</div>


</div>


</div>





<div class="bg-gray-700 shadow rounded-xl p-6">


<h2 class="text-xl font-bold mb-5 uppercase">
Interview Details
</h2>




<div class="space-y-5">


<div>

<label>
Interview Date
</label>

<input

type="datetime-local"

v-model="form.interviewDate"

class="w-full border-3 p-3 rounded-lg "

/>

</div>




<div>

<label>
Interview Type
</label>


<select
v-model="form.interviewType"

class="w-full border-3 p-3 rounded-lg">


<option>
Technical
</option>


<option>
HR
</option>


<option>
Final
</option>


</select>


</div>




<div>

<label>
Notes
</label>


<textarea

v-model="form.notes"

rows="4"

class="w-full border-3 p-3 rounded-lg">

</textarea>


</div>


</div>


</div>




<button

class="bg-blue-600 text-white px-8 py-3 rounded-lg">

Schedule Interview

</button>



</form>


</div>


</template>



<script setup>


import {reactive,onMounted} from "vue";

import {useRoute,useRouter} from "vue-router";

import {createInterview} from "../../api/interview";



const route=useRoute();

const router=useRouter();



const form=reactive({

applicationId:"",

candidateId:"",

candidateName:"",

jobId:"",

jobTitle:"",

interviewDate:"",

interviewType:"Technical",

notes:""

});





onMounted(()=>{


form.applicationId =
route.query.applicationId;


form.candidateId =
route.query.candidateId;


form.candidateName =
route.query.candidateName;


form.jobId =
route.query.jobId;


form.jobTitle =
route.query.jobTitle;



});





const submitInterview=async()=>{


try{


await createInterview({

    applicationId:
    Number(form.applicationId),

    candidateId:
    Number(form.candidateId),

    jobId:
    Number(form.jobId),

    interviewDate:
    form.interviewDate,

    interviewType:
    form.interviewType,

    notes:
    form.notes


});



alert(
"Interview scheduled successfully"
);



router.push(
"/recruiter/interviews"
);



}

catch(error){


console.error(error);


alert(
"Failed to schedule interview"
);


}



};



</script>