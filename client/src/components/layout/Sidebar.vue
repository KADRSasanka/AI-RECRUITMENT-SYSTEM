<template>

<aside 
class="w-64 bg-slate-900 text-white min-h-screen p-5">


<h1 class="text-2xl font-bold mb-8" style="font-family: 'Space Grotesk', sans-serif;">

Aptivo

</h1>



<nav class="space-y-3">

<!-- Administrator -->

<router-link
v-if="auth.role==='Administrator'"
to="/admin/dashboard"
class="block hover:bg-slate-700 p-3 rounded">
Dashboard
</router-link>


<router-link
v-if="auth.role==='Administrator'"
to="/admin/users"
class="block hover:bg-slate-700 p-3 rounded">
Users
</router-link>


<router-link
v-if="auth.role==='Administrator'"
to="/admin/organizations"
class="block hover:bg-slate-700 p-3 rounded">
Organizations
</router-link>


<router-link
v-if="auth.role==='Administrator'"
to="/admin/departments"
class="block hover:bg-slate-700 p-3 rounded">
Departments
</router-link>


<!-- Recruiter -->

<router-link
v-if="auth.role==='Recruiter'"
to="/recruiter/dashboard"
class="block hover:bg-slate-700 p-3 rounded">
Dashboard
</router-link>


<router-link
v-if="auth.role==='Recruiter'"
to="/recruiter/jobs"
class="block hover:bg-slate-700 p-3 rounded">
Jobs
</router-link>

<router-link
    v-if="auth.role==='Recruiter'"
    to="/recruiter/applications"
    class="block hover:bg-slate-700 p-3 rounded">

    Applications

</router-link>


<router-link
    v-if="auth.role==='Recruiter'"
    to="/recruiter/interviews"
    class="block hover:bg-slate-700 p-3 rounded">

    Interviews

</router-link>


<!-- Hiring Manager -->

<router-link
v-if="auth.role==='Hiring Manager'"
to="/manager/dashboard"
class="block hover:bg-slate-700 p-3 rounded">

Dashboard

</router-link>


<router-link
v-if="auth.role==='Hiring Manager'"
to="/manager/jobs"
class="block hover:bg-slate-700 p-3 rounded">

Jobs

</router-link>


<router-link
v-if="auth.role==='Hiring Manager'"
to="/manager/applications"
class="block hover:bg-slate-700 p-3 rounded">

Applications

</router-link>


<router-link
v-if="auth.role==='Hiring Manager'"
to="/manager/interviews"
class="block hover:bg-slate-700 p-3 rounded">

Interviews

</router-link>


<!-- Candidate -->

<router-link
v-if="auth.role==='Candidate'"
to="/candidate/dashboard"
class="block hover:bg-slate-700 p-3 rounded">

Dashboard

</router-link>


</nav>


</aside>


</template>


<script setup>

import { useAuthStore } from "../../stores/authStore_old";

const auth = useAuthStore();

</script>