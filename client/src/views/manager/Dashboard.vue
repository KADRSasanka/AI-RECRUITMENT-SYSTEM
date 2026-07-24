<template>
<div class="max-w-7xl mx-auto">

    <div class="mb-8">

        <h1 class="text-3xl font-bold">
            Hiring Manager Dashboard
        </h1>

        <p class="text-gray-500 mt-2">
            Review assigned vacancies, candidate progress and interviews.
        </p>

    </div>

    <div
        v-if="loading"
        class="text-center py-16">

        Loading Dashboard...

    </div>

    <div
        v-else>

        <!-- Stats -->

        <div class="grid lg:grid-cols-4 md:grid-cols-2 gap-6">

            <div class="bg-white rounded-xl shadow p-6">

                <h3 class="text-gray-500">
                    Assigned Jobs
                </h3>

                <p class="text-4xl font-bold mt-3">
                    {{ jobs }}
                </p>

            </div>

            <div class="bg-white rounded-xl shadow p-6">

                <h3 class="text-gray-500">
                    Applications
                </h3>

                <p class="text-4xl font-bold mt-3">
                    {{ applications }}
                </p>

            </div>

            <div class="bg-white rounded-xl shadow p-6">

                <h3 class="text-gray-500">
                    Interviews
                </h3>

                <p class="text-4xl font-bold mt-3">
                    {{ interviews }}
                </p>

            </div>

            <div class="bg-white rounded-xl shadow p-6">

                <h3 class="text-gray-500">
                    Pending Reviews
                </h3>

                <p class="text-4xl font-bold mt-3">
                    {{ pendingReviews }}
                </p>

            </div>

        </div>

        <!-- Quick Actions -->

        <div class="grid md:grid-cols-3 gap-6 mt-10">

            <router-link
                to="/manager/jobs"
                class="bg-blue-600 text-white rounded-xl p-6 hover:bg-blue-700">

                <h2 class="text-xl font-semibold">
                    Assigned Jobs
                </h2>

                <p class="mt-2">
                    View all jobs assigned to you.
                </p>

            </router-link>

            <router-link
                to="/manager/applications"
                class="bg-green-600 text-white rounded-xl p-6 hover:bg-green-700">

                <h2 class="text-xl font-semibold">
                    Candidate Reviews
                </h2>

                <p class="mt-2">
                    Review shortlisted candidates.
                </p>

            </router-link>

            <router-link
                to="/manager/interviews"
                class="bg-purple-600 text-white rounded-xl p-6 hover:bg-purple-700">

                <h2 class="text-xl font-semibold">
                    Interview Schedule
                </h2>

                <p class="mt-2">
                    Check upcoming interviews.
                </p>

            </router-link>

        </div>

    </div>

</div>
</template>

<script setup>

import { ref, onMounted } from "vue";

import api from "../../api/axios";

const loading = ref(true);

const jobs = ref(0);
const applications = ref(0);
const interviews = ref(0);
const pendingReviews = ref(0);

const loadDashboard = async () => {

    try {

        const [
            jobResponse,
            applicationResponse,
            interviewResponse
        ] = await Promise.all([

            api.get("/HiringManager/jobs"),

            api.get("/HiringManager/applications"),

            api.get("/HiringManager/interviews")

        ]);

        jobs.value = jobResponse.data.length;

        applications.value = applicationResponse.data.length;

        interviews.value = interviewResponse.data.length;

        pendingReviews.value =
            applicationResponse.data.filter(
                x =>
                    x.status === "Interview Completed" ||
                    x.status === "Shortlisted"
            ).length;

    }

    catch (error) {

        console.error(error);

    }

    finally {

        loading.value = false;

    }

};

onMounted(loadDashboard);

</script>