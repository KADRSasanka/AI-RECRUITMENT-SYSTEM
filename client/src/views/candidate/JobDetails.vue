<template>

<div
v-if="job"
class="max-w-4xl mx-auto">


<h1 class="text-3xl font-bold">

{{job.jobTitle}}

</h1>


<p class="text-gray-400 mt-2">

{{job.organizationName}}

</p>



<div class="bg-gray-700 rounded-xl p-6 mt-8">


<h2 class="text-xl font-bold">
Description
</h2>


<p class="mt-4">

{{job.jobDescription}}

</p>



<div class="grid md:grid-cols-2 gap-5 mt-6">


<p>
Location:
{{job.location}}
</p>


<p>
Type:
{{job.employmentType}}
</p>


<p>
Experience:
{{job.experienceLevel}}
</p>


<p>
Vacancies:
{{job.numberOfVacancies}}
</p>


</div>


<button

@click="apply"

class="mt-8 bg-green-600 px-8 py-3 rounded-lg text-white">

Apply Now

</button>



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
useRoute,
useRouter
}
from "vue-router";


import {
getJob
}
from "../../api/job";


import {
createApplication
}
from "../../api/application";



const route=useRoute();

const router=useRouter();



const job=ref(null);





const load=async()=>{


const response =
await getJob(
route.params.id
);


job.value=response.data;


};






const apply=async()=>{


try{


await createApplication({

candidateId:
localStorage.getItem("userId"),


jobId:
job.value.jobId

});


alert(
"Application submitted!"
);



router.push(
"/candidate/applications"
);


}

catch(error){

console.error(error);

alert(
"Unable to apply"
);

}


};




onMounted(load);


</script>