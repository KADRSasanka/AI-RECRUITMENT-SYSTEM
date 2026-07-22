<template>

<aside 
class="w-64 bg-slate-900 text-white min-h-screen p-5">


<h1 class="text-2xl font-bold mb-8">

AI Recruit

</h1>



<nav class="space-y-3">

<router-link
to="/admin/dashboard"
class="block hover:bg-slate-700 p-3 rounded">
Dashboard
</router-link>


<router-link
to="/admin/users"
class="block hover:bg-slate-700 p-3 rounded">
Users
</router-link>


<router-link
to="/admin/organizations"
class="block hover:bg-slate-700 p-3 rounded">
Organizations
</router-link>


<router-link
to="/admin/departments"
class="block hover:bg-slate-700 p-3 rounded">
Departments
</router-link>

</nav>


</aside>


</template>