<template>

<div>

    <!-- Page Header -->

    <div class="flex items-center justify-between mb-8">

        <div>

            <h1 class="text-3xl font-bold">
                Job Management
            </h1>

            <p class="text-gray-500 mt-1">
                Manage all published job vacancies.
            </p>

        </div>


        <router-link
            to="/recruiter/jobs/create"
            class="bg-blue-600 hover:bg-blue-700 text-white px-5 py-3 rounded-lg font-medium transition">

            + Create Job

        </router-link>

    </div>



    <!-- Loading -->

    <div
        v-if="loading"
        class="text-center py-10 text-gray-500">

        Loading jobs...

    </div>



    <!-- Error -->

    <div
        v-else-if="error"
        class="bg-red-100 text-red-600 p-4 rounded-lg">

        {{ error }}

    </div>



    <!-- Table -->

    <div
        v-else
        class="bg-white rounded-xl shadow overflow-hidden">

        <table class="min-w-full">

            <thead class="bg-gray-100">

                <tr class="justify-center">

                    <th class="px-6 py-4">Job Title</th>

                    <th class="px-6 py-4">Organization</th>

                    <th class="px-6 py-4">Department</th>

                    <th class="px-6 py-4">Closing Date</th>

                    <th class="px-6 py-4 text-center">Vacancies</th>

                    <th class="px-6 py-4 text-center">Status</th>

                    <th class="px-6 py-4 text-center">Actions</th>

                </tr>

            </thead>


            <tbody>

                <tr
                    v-for="job in jobs"
                    :key="job.jobId"
                    class="border-t hover:bg-gray-50">

                    <!-- Title -->

                    <td class="px-4 py-4">

                        <div class="text-sm font-semibold">

                            {{ job.jobTitle }}

                        </div>

                        <div class="text-sm text-gray-500">

                            {{ job.location }}

                        </div>

                    </td>


                    <!-- Organization -->

                    <td class="text-sm px-4 py-4">

                        {{ job.organizationName }}

                    </td>


                    <!-- Department -->

                    <td class="text-sm px-4 py-4">

                        {{ job.departmentName }}

                    </td>


                    <!-- Closing -->

                    <td class="text-sm px-4 py-4">

                        {{ formatDate(job.closingDate) }}

                    </td>


                    <!-- Vacancies -->

                    <td class="text-sm px-4 py-4 text-center">

                        {{ job.numberOfVacancies }}

                    </td>


                    <!-- Status -->

                    <td class="text-sm px-4 py-4 text-center">

                        <span
                            v-if="job.isActive"
                            class="bg-green-100 text-green-700 px-3 py-1 rounded-full text-sm">

                            Active

                        </span>

                        <span
                            v-else
                            class="bg-red-100 text-red-700 px-3 py-1 rounded-full text-sm">

                            Closed

                        </span>

                    </td>


                    <!-- Actions -->

                    <td class="px-4 py-4">

                        <div class="flex justify-center gap-2">

                            <button
                                @click="viewJob(job.jobId)"
                                class="bg-blue-500 hover:bg-blue-600 text-white px-3 py-2 rounded">

                                👁

                            </button>

                            <button
                                @click="editJob(job.jobId)"
                                class="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-2 rounded">

                                ✏

                            </button>

                            <button
                                @click="viewApplicants(job.jobId)"
                                class="bg-green-600 hover:bg-green-700 text-white px-3 py-2 rounded">

                                <router-link
                                :to="`/recruiter/jobs/${job.jobId}/applicants`"
                                class="text-purple-600">

                                    👥

                                </router-link>

                            </button>

                        </div>

                    </td>

                </tr>


                <tr v-if="jobs.length === 0">

                    <td
                        colspan="7"
                        class="text-center py-10 text-gray-500">

                        No jobs found.

                    </td>

                </tr>

            </tbody>

        </table>

    </div>

</div>

</template>

<script setup>

import { ref, onMounted } from "vue";

import { useRouter } from "vue-router";

import { getJobs } from "../../api/job";

const router = useRouter();

const jobs = ref([]);

const loading = ref(true);

const error = ref("");

const loadJobs = async () => {

    try {

        const response = await getJobs();

        jobs.value = response.data;

    }

    catch (err) {

        console.error(err);

        error.value = "Failed to load jobs.";

    }

    finally {

        loading.value = false;

    }

};

const formatDate = (date) => {

    return new Date(date).toLocaleDateString();

};

const viewJob = (id) => {

    router.push(`/jobs/${id}`);

};

const editJob = (id) => {

    router.push(`/recruiter/jobs/edit/${id}`);

};

const viewApplicants = (id) => {

    router.push(`/recruiter/jobs/${id}/applications`);

};

onMounted(() => {

    loadJobs();

});

</script>