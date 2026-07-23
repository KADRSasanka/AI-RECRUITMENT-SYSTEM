<template>

<div class="bg-gray-700 rounded-xl shadow p-6">


<p class="text-gray-200">

{{title}}

</p>



<h2 class="text-4xl font-bold mt-3">

{{value}}

</h2>


</div>

</template>


<script setup>

defineProps({

title:String,

value:Number

});

</script>