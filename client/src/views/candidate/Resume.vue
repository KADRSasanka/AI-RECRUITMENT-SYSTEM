<template>

<div class="max-w-5xl mx-auto">

    <div class="flex justify-between items-center mb-8">

        <div>

            <h1 class="text-3xl font-bold">
                Resume Management
            </h1>

            <p class="text-gray-400 mt-2">
                Upload and manage your professional resume.
            </p>

        </div>

    </div>



    <!-- Upload -->

    <div class="bg-gray-700 rounded-xl p-6">

        <h2 class="text-xl font-semibold mb-5">

            Upload Resume

        </h2>

        <input
            type="file"
            accept=".pdf"
            @change="selectFile"
            class="mb-5"/>

        <button
            @click="upload"
            class="bg-blue-600 px-6 py-3 rounded-lg text-white">

            Upload Resume

        </button>

    </div>



    <!-- Resume List -->

    <div
        class="mt-8 bg-gray-700 rounded-xl p-6">

        <h2 class="text-xl font-semibold mb-5">

            My Resume

        </h2>

        <table
            class="w-full">

            <thead>

                <tr class="border-b">

                    <th class="text-left p-3">

                        File

                    </th>

                    <th>

                        Size

                    </th>

                    <th>

                        Uploaded

                    </th>

                    <th>

                        Actions

                    </th>

                </tr>

            </thead>

            <tbody>

                <tr
                    v-for="resume in resumes"
                    :key="resume.resumeId"
                    class="border-b">

                    <td class="p-3">

                        {{resume.fileName}}

                    </td>

                    <td>

                        {{formatSize(resume.fileSize)}}

                    </td>

                    <td>

                        {{formatDate(resume.uploadedAt)}}

                    </td>

                    <td class="space-x-3">

                        <a

                            :href="downloadResume(resume.resumeId)"

                            target="_blank"

                            class="text-blue-400">

                            View

                        </a>

                        <button

                            @click="remove(resume.resumeId)"

                            class="text-red-400">

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

uploadResume,

getCandidateResumes,

deleteResume,

downloadResume

}

from "../../api/resume";

const resumes=ref([]);

const file=ref(null);

const candidateId=
localStorage.getItem("userId");

const selectFile=(event)=>{

file.value=
event.target.files[0];

};

const load=async()=>{

const response=
await getCandidateResumes(candidateId);

resumes.value=response.data;

};

const upload=async()=>{

if(!file.value){

alert("Select a PDF.");

return;

}

const formData=
new FormData();

formData.append(
"candidateId",
candidateId
);

formData.append(
"resume",
file.value
);

await uploadResume(formData);

alert("Resume uploaded.");

load();

};

const remove=async(id)=>{

if(confirm("Delete resume?")){

await deleteResume(id);

load();

}

};

const formatDate=(date)=>{

return new Date(date)
.toLocaleDateString();

};

const formatSize=(size)=>{

return (size/1024/1024)
.toFixed(2)+" MB";

};

onMounted(load);

</script>