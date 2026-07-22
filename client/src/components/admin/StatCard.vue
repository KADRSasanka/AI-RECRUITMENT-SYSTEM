<template>

<div class="bg-white rounded-xl shadow p-6">

    <h3 class="text-gray-500 text-sm">
        {{title}}
    </h3>


    <p class="text-4xl font-bold mt-3">
        {{value}}
    </p>


</div>

</template>


<script setup>

defineProps({

    title:{
        type:String,
        required:true
    },


    value:{
        type:[String,Number],
        required:true
    }

});

</script>