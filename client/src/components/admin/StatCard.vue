<template>
  <div class="bg-gray-700 rounded-xl shadow p-6">
    <div class="flex items-center justify-between">
      <h3 class="text-gray-100 text-sm">{{ title }}</h3>
      <span class="h-2.5 w-2.5 rounded-full" :class="dotClass"></span>
    </div>

    <p class="text-4xl font-bold mt-3">{{ formattedValue }}</p>
  </div>
</template>

<script setup>
import { computed } from "vue";

const props = defineProps({
  title: {
    type: String,
    required: true,
  },
  value: {
    type: [String, Number],
    required: true,
  },
  accent: {
    type: String,
    default: "indigo",
    validator: (v) => ["indigo", "emerald", "amber"].includes(v),
  },
});

const accentDotMap = {
  indigo: "bg-indigo-500",
  emerald: "bg-emerald-500",
  amber: "bg-amber-500",
};

const dotClass = computed(() => accentDotMap[props.accent]);

const formattedValue = computed(() => {
  const num = Number(props.value);
  return Number.isFinite(num) ? num.toLocaleString() : props.value;
});
</script>