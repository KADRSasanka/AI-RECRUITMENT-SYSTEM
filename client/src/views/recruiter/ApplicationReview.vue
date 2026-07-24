<template>

<div class="max-w-5xl mx-auto">

    <div class="flex justify-between items-center mb-8">

        <div>

            <h1 class="text-3xl font-bold">
                Application Review
            </h1>

            <p class="text-gray-500">
                Review candidate and update recruitment progress.
            </p>

        </div>

        <router-link
            to="/recruiter/dashboard"
            class="bg-gray-600 text-white px-5 py-2 rounded-lg">

            ← Back

        </router-link>

    </div>



    <div
        v-if="loading"
        class="text-center py-20">

        Loading application...

    </div>



    <div
        v-else
        class="space-y-6">

        <!-- Candidate -->

        <div class="bg-gray-700 rounded-xl shadow p-6">

            <h2 class="text-xl font-semibold mb-5">
                Candidate Information
            </h2>

            <div class="grid md:grid-cols-2 gap-6">

                <div>

                    <label class="text-gray-200">
                        Candidate
                    </label>

                    <p class="font-semibold text-lg">

                        {{ application.candidateName }}

                    </p>

                </div>

                <div>

                    <label class="text-gray-200">
                        Job
                    </label>

                    <p>

                        {{ application.jobTitle }}

                    </p>

                </div>

                <div>

                    <label class="text-gray-200">
                        Applied Date
                    </label>

                    <p>

                        {{ formatDate(application.appliedDate) }}

                    </p>

                </div>

                <div>

                    <label class="text-gray-200">
                        Current Status
                    </label>

                    <p>

                        {{ application.status }}

                    </p>

                </div>

            </div>

        </div>




        <!-- AI Analysis -->

        <div class="bg-gray-700 rounded-xl shadow p-6">


            <h2 class="text-xl font-semibold mb-5">
            AI Candidate Evaluation
            </h2>



            <div v-if="aiLoading">

                Analyzing candidate...

            </div>



            <div v-else>


                <div class="flex gap-8 items-center">


                    <div
                    class="w-32 h-32 rounded-full bg-purple-100 flex items-center justify-center">

                        <span class="text-3xl font-bold text-purple-700">

                        {{aiResult.matchScore ?? 0}}%

                        </span>

                    </div>


                <div>


                <h3 class="text-xl font-bold">

                    {{aiResult.recommendation}}

                </h3>


                <p class="mt-3">

                    <strong>
                    Strengths:
                    </strong>

                    {{aiResult.strengths}}

                </p>


                <p class="mt-3">

                    <strong>
                    Missing Skills:
                    </strong>

                    {{aiResult.missingSkills}}

                </p>


            </div>



        </div>


        </div>


        </div>





        <!-- Review -->

        <div class="bg-gray-700 rounded-xl shadow p-6">

            <h2 class="text-xl font-semibold mb-5">

                Recruiter Decision

            </h2>

            <div class="space-y-5">

                <div>

                    <label class="block mb-2 font-medium">

                        Status

                    </label>

                    <select
                        v-model="application.status"
                        class="border rounded-lg w-full p-3">

                        <option>Applied</option>

                        <option>Shortlisted</option>

                        <option>Interview Scheduled</option>

                        <option>Rejected</option>

                        <option>Hired</option>

                    </select>

                </div>

                <div>

                    <label class="block mb-2 font-medium">

                        Recruiter Remarks

                    </label>

                    <textarea
                        rows="5"
                        class="border rounded-lg w-full p-3"
                        v-model="application.recruiterRemarks">

                    </textarea>

                </div>

            </div>

        </div>





        <div class="flex gap-4">

            <button
                @click="save"
                class="bg-green-600 text-white px-6 py-3 rounded-lg">

                Save Changes

            </button>

            <button
                @click="scheduleInterview"
                class="bg-blue-600 text-white px-6 py-3 rounded-lg">

                Schedule Interview

            </button>

        </div>

    </div>

</div>

</template>

<script setup>

import { ref, computed, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";

import {
    getApplication,
    updateApplication
} from "../../api/application";

import {
analyzeCandidate
}
from "../../api/ai";

const route = useRoute();
const router = useRouter();

const loading = ref(true);
const application = ref({});

const aiResult = ref({});
const aiLoading = ref(false);

const recommendation=computed(()=>{

const score=application.value.score ?? 0;

if(score>=90) return "Excellent Match";

if(score>=75) return "Very Good Match";

if(score>=60) return "Good Match";

if(score>=40) return "Average Match";

return "Poor Match";

});


const loadAI = async()=>{


try{


aiLoading.value=true;



const response =
await analyzeCandidate(

application.value.candidateId,

application.value.jobId

);



aiResult.value =
response.data;


}

catch(error){

console.error(error);

}

finally{

aiLoading.value=false;

}


};


const loadApplication=async()=>{

try{

const response=
await getApplication(route.params.id);

application.value=response.data;

}
catch(err){

console.error(err);

}
finally{

loading.value=false;

}

};

const save=async()=>{

try{

await updateApplication(

application.value.applicationId,

{

status:application.value.status,

recruiterRemarks:application.value.recruiterRemarks,

score:application.value.score,

aiRecommendation:application.value.aiRecommendation

}

);

alert("Application updated successfully.");

}
catch(err){

console.error(err);

alert("Unable to update application.");

}

};

const scheduleInterview=()=>{

router.push({

    path:"/recruiter/interviews/create",

    query:{

        applicationId:
        application.value.applicationId,

        candidateId:
        application.value.candidateId,

        candidateName:
        application.value.candidateName,

        jobId:
        application.value.jobId,

        jobTitle:
        application.value.jobTitle

    }

});

};

const formatDate=(date)=>{

return new Date(date).toLocaleDateString();

};

onMounted(async()=>{

await loadApplication();

await loadAI();

});

</script>