<template>
<div class="max-w-6xl mx-auto">

    <div class="flex justify-between items-center mb-8">

        <div>

            <h1 class="text-3xl font-bold">
                Hiring Manager Review
            </h1>

            <p class="text-gray-500 mt-2">
                Review interview results and make the final hiring decision.
            </p>

        </div>

        <router-link
            to="/manager/applications"
            class="bg-gray-600 text-white px-5 py-3 rounded-lg">

            ← Back

        </router-link>

    </div>





    <div
        v-if="loading"
        class="bg-white rounded-xl shadow p-10 text-center">

        Loading application...

    </div>





    <div
        v-else
        class="space-y-6">




        <!-- Candidate -->

        <div class="bg-gray-700 rounded-xl shadow p-6">

            <h2 class="text-xl font-semibold mb-6">

                Candidate Details

            </h2>

            <div class="grid md:grid-cols-2 gap-6">

                <div>

                    <label class="text-gray-500">
                        Candidate
                    </label>

                    <p class="font-semibold text-lg text-gray-300">

                        {{ application.candidateName }}

                    </p>

                </div>

                <div>

                    <label class="text-gray-500">
                        Job Position
                    </label>

                    <p class="text-gray-300">

                        {{ application.jobTitle }}

                    </p>

                </div>

                <div>

                    <label class="text-gray-500">
                        Applied Date
                    </label>

                    <p class="text-gray-300">

                        {{ formatDate(application.appliedDate) }}

                    </p>

                </div>

                <div>

                    <label class="text-gray-500">
                        Current Status
                    </label>

                    <p class="text-gray-300">

                        {{ application.status }}

                    </p>

                </div>

            </div>

        </div>







        <!-- AI -->

        <div class="bg-gray-700 rounded-xl shadow p-6">

            <h2 class="text-xl font-semibold mb-6">

                AI Evaluation

            </h2>

            <div class="flex gap-8 items-center">

                <div
                    class="w-32 h-32 rounded-full bg-blue-100 flex items-center justify-center">

                    <span class="text-3xl font-bold text-blue-700">

                        {{ application.score ?? 0 }}%

                    </span>

                </div>

                <div>

                    <h3 class="font-bold text-xl text-gray-300">

                        {{ recommendation }}

                    </h3>

                    <p class="text-gray-500 mt-2">

                        {{ application.aiRecommendation || "No AI recommendation available." }}

                    </p>

                </div>

            </div>

        </div>








        <!-- Recruiter -->

        <div class="bg-gray-700 rounded-xl shadow p-6">

            <h2 class="text-xl font-semibold mb-5">

                Recruiter Notes

            </h2>

            <textarea
                disabled
                rows="5"
                class="w-full border-3 border-gray-500 rounded-lg p-4 bg-gray-700">

{{ application.recruiterRemarks || "No recruiter remarks." }}

            </textarea>

        </div>








        <!-- Manager -->

        <div class="bg-gray-700 rounded-xl shadow p-6">

            <h2 class="text-xl font-semibold mb-6">

                Final Decision

            </h2>

            <div class="space-y-5">

                <div>

                    <label class="block mb-2 text-left">

                        Decision

                    </label>

                    <select
                        v-model="review.status"
                        class="w-full border-3 border-gray-500 rounded-lg p-3">

                        <option>Approved</option>

                        <option>Rejected</option>

                        <option>Needs Further Interview</option>

                    </select>

                </div>

                <div>

                    <label class="block mb-2 text-left">

                        Hiring Manager Remarks

                    </label>

                    <textarea
                        rows="6"
                        class="w-full border-3 border-gray-500 rounded-lg p-4"
                        v-model="review.hiringManagerRemarks">

                    </textarea>

                </div>

            </div>

        </div>








        <div class="flex gap-4">

            <button
                @click="saveDecision"
                class="bg-green-600 hover:bg-green-700 text-white px-8 py-3 rounded-lg">

                Save Decision

            </button>

        </div>

    </div>

</div>
</template>

<script setup>

import {ref,onMounted,computed} from "vue";

import {useRoute,useRouter} from "vue-router";

import {
getApplication,
managerReview
}
from "../../api/application";


const route=useRoute();

const router=useRouter();


const loading=ref(true);

const application=ref({});


const review=ref({

status:"Approved",

hiringManagerRemarks:""

});



const recommendation=computed(()=>{

const score=application.value.score ?? 0;

if(score>=90) return "Excellent Candidate";

if(score>=75) return "Strong Candidate";

if(score>=60) return "Good Candidate";

if(score>=40) return "Average Candidate";

return "Weak Candidate";

});



const loadApplication=async()=>{

try{

const response=
await getApplication(route.params.id);

application.value=response.data;

review.value.status=response.data.status;

review.value.hiringManagerRemarks=
response.data.hiringManagerRemarks ?? "";

}
catch(err){

console.error(err);

}
finally{

loading.value=false;

}

};



const saveDecision=async()=>{

try{

await managerReview(

application.value.applicationId,

review.value

);

alert("Decision saved successfully.");

router.push("/manager/applications");

}
catch(err){

console.error(err);

alert("Unable to save decision.");

}

};



const formatDate=(date)=>{

return new Date(date)
.toLocaleDateString();

};



onMounted(loadApplication);

</script>