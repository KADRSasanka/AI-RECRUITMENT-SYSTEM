<template>

<div class="min-h-screen bg-gray-800 flex">


    <!-- Sidebar -->

    <Sidebar />



    <div class="flex-1">


        <!-- Navbar -->

        <Navbar />



        <!-- Page Content -->

        <main class="p-6">

            <router-view />

        </main>


    </div>


</div>


</template>



<script setup>

import Sidebar from "../components/layout/Sidebar.vue";

import Navbar from "../components/layout/Navbar.vue";


</script>