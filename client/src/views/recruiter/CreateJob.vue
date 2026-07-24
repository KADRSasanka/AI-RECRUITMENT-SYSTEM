<template>
<div class="max-w-5xl mx-auto">

    <div class="flex justify-between items-center mb-8">

        <div>
            <h1 class="text-3xl font-bold">
                Create New Job
            </h1>
            <p class="text-gray-500 mt-2">
                Fill the details below to publish a new vacancy.
            </p>
        </div>

        <router-link
            to="/recruiter/jobs"
            class="bg-gray-600 px-6 py-2 rounded-lg hover:bg-gray-300">

            ⏪ Back

        </router-link>

    </div>

    <div
        v-if="error"
        class="mb-6 bg-red-100 border border-red-300 text-red-600 rounded-lg p-3">
        {{ error }}
    </div>

    <form
        @submit.prevent="submitJob"
        class="space-y-8">

        <!-- Job Information -->
        <div class="bg-gray-600 rounded-xl shadow p-6">
            <h2 class="text-xl font-semibold mb-5 uppercase">
                Job Information
            </h2>

            <div class="grid md:grid-cols-2 gap-5">

                <div>
                    <label class="block mb-2 font-medium">Organization</label>
                    <select
                        v-model="form.organizationId"
                        required
                        class="w-full border rounded-lg p-3">
                        <option value="">Select Organization</option>
                        <option
                            v-for="org in organizations"
                            :key="org.organizationId"
                            :value="org.organizationId">
                            {{ org.organizationName }}
                        </option>
                    </select>
                </div>

                <div>
                    <label class="block mb-2 font-medium">Department</label>
                    <select
                        v-model="form.departmentId"
                        required
                        class="w-full border rounded-lg p-3">
                        <option value="">Select Department</option>
                        <option
                            v-for="department in departments"
                            :key="department.departmentId"
                            :value="department.departmentId">
                            {{ department.departmentName }}
                        </option>
                    </select>
                </div>

                <div>
                    <label class="block mb-2 font-medium">Recruiter</label>
                    <select
                        v-model="form.recruiterId"
                        required
                        class="w-full border rounded-lg p-3">
                        <option value="">Select Recruiter</option>
                        <option
                            v-for="user in recruiters"
                            :key="user.userId"
                            :value="user.userId">
                            {{ user.firstName }} {{ user.lastName }}
                        </option>
                    </select>
                </div>

                <div>
                    <label class="block mb-2 font-medium">Job Title</label>
                    <input
                        v-model="form.jobTitle"
                        required
                        class="w-full border rounded-lg p-3"
                        placeholder="Software Engineer" />
                </div>

            </div>


            <div>

                <label class="block mb-2 font-medium">
                Hiring Manager
                </label>


                <select
                v-model="form.hiringManagerId"
                class="w-full border rounded-lg p-3">


                    <option value="">
                    Select Hiring Manager
                    </option>


                    <option
                    v-for="user in hiringManagers"
                    :key="user.userId"
                    :value="user.userId">

                    {{user.firstName}} {{user.lastName}}

                    </option>


                </select>


            </div>


            <div class="mt-5">
                <label class="block mb-2 font-medium">Job Description</label>
                <textarea
                    v-model="form.jobDescription"
                    required
                    rows="6"
                    class="w-full border rounded-lg p-3">
                </textarea>
            </div>
        </div>

        <!-- Employment -->
        <div class="bg-gray-600 rounded-xl shadow p-6">
            <h2 class="text-xl font-semibold mb-5 uppercase">
                Employment Details
            </h2>

            <div class="grid md:grid-cols-2 gap-5">

                <div>
                    <label class="block mb-2">Employment Type</label>
                    <select
                        v-model="form.employmentType"
                        class="w-full border rounded-lg p-3">
                        <option>Full Time</option>
                        <option>Part Time</option>
                        <option>Contract</option>
                        <option>Internship</option>
                    </select>
                </div>

                <div>
                    <label class="block mb-2">Work Mode</label>
                    <select
                        v-model="form.workMode"
                        class="w-full border rounded-lg p-3">
                        <option>Onsite</option>
                        <option>Hybrid</option>
                        <option>Remote</option>
                    </select>
                </div>

                <div>
                    <label class="block mb-2">Experience Level</label>
                    <select
                        v-model="form.experienceLevel"
                        class="w-full border rounded-lg p-3">
                        <option>Entry Level</option>
                        <option>Junior</option>
                        <option>Mid Level</option>
                        <option>Senior</option>
                    </select>
                </div>

                <div>
                    <label class="block mb-2">Location</label>
                    <input
                        v-model="form.location"
                        required
                        class="w-full border rounded-lg p-3" />
                </div>

            </div>
        </div>

        <!-- Salary -->
        <div class="bg-gray-600 rounded-xl shadow p-6">
            <h2 class="text-xl font-semibold mb-5 uppercase">
                Salary
            </h2>

            <div class="grid md:grid-cols-3 gap-5">

                <div>
                    <label class="block mb-2">Minimum</label>
                    <input
                        type="number"
                        v-model="form.salaryMin"
                        class="w-full border rounded-lg p-3" />
                </div>

                <div>
                    <label class="block mb-2">Maximum</label>
                    <input
                        type="number"
                        v-model="form.salaryMax"
                        class="w-full border rounded-lg p-3" />
                </div>

                <div>
                    <label class="block mb-2">Currency</label>
                    <input
                        v-model="form.currency"
                        class="w-full border rounded-lg p-3" />
                </div>

            </div>
        </div>

        <!-- Vacancy -->
        <div class="bg-gray-600 rounded-xl shadow p-6">
            <h2 class="text-xl font-semibold mb-5 uppercase">
                Vacancy
            </h2>

            <div class="grid md:grid-cols-2 gap-5">

                <div>
                    <label class="block mb-2">Vacancies</label>
                    <input
                        type="number"
                        v-model="form.numberOfVacancies"
                        class="w-full border rounded-lg p-3" />
                </div>

                <div>
                    <label class="block mb-2">Closing Date</label>
                    <input
                        type="date"
                        v-model="form.closingDate"
                        required
                        class="w-full border rounded-lg p-3" />
                </div>

            </div>
        </div>

        <button
            :disabled="loading"
            class="bg-blue-600 text-white px-8 py-3 rounded-lg disabled:opacity-50">
            {{ loading ? "Creating..." : "Create Job" }}
        </button>

    </form>

</div>
</template>

<script setup>

import { ref, onMounted } from "vue";
import { useRouter } from "vue-router";

import { getOrganizations } from "../../api/organization";
import { getDepartments } from "../../api/department";
import { getUsers } from "../../api/user";
import { createJob } from "../../api/job";

const router = useRouter();

const organizations = ref([]);
const departments = ref([]);
const recruiters = ref([]);
const hiringManagers = ref([]);

const loading = ref(false);
const error = ref("");

const form = ref({
    organizationId: "",
    departmentId: "",
    recruiterId: "",
    hiringManagerId:"",
    jobTitle: "",
    jobDescription: "",
    employmentType: "Full Time",
    workMode: "Onsite",
    location: "",
    experienceLevel: "Entry Level",
    salaryMin: null,
    salaryMax: null,
    currency: "LKR",
    numberOfVacancies: 1,
    closingDate: ""
});

onMounted(async () => {

    organizations.value = (await getOrganizations()).data;
    departments.value = (await getDepartments()).data;

    const users = (await getUsers()).data;

    recruiters.value = users.filter(
        u => u.role === "Recruiter"
    );

    hiringManagers.value = users.filter(
        u=>u.role==="Hiring Manager"
    );

});

const submitJob = async () => {

    if (
        !form.value.organizationId ||
        !form.value.departmentId ||
        !form.value.recruiterId ||
        !form.value.jobTitle ||
        !form.value.jobDescription ||
        !form.value.location ||
        !form.value.closingDate
    ) {
        alert("Please fill all required fields.");
        return;
    }

    if (
        form.value.salaryMin &&
        form.value.salaryMax &&
        Number(form.value.salaryMin) > Number(form.value.salaryMax)
    ) {
        alert("Minimum salary cannot exceed maximum salary.");
        return;
    }

    const today = new Date();
    today.setHours(0, 0, 0, 0);

    if (new Date(form.value.closingDate) < today) {
        alert("Closing date cannot be in the past.");
        return;
    }

    loading.value = true;
    error.value = "";

    try {

        await createJob(form.value);

        alert("Job created successfully!");

        router.push("/recruiter/jobs");

    }

    catch (err) {

        console.error(err);

        error.value =
            err.response?.data?.message ??
            "Unable to create job.";

    }

    finally {

        loading.value = false;

    }

};

</script>