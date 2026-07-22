<template>
  <div class="min-h-screen bg-slate-50 px-6 py-8 md:px-10">
    <div class="mx-auto max-w-6xl">

      <!-- Header -->
      <div class="flex flex-col gap-1 border-b border-slate-200 pb-6">
        <h1 class="text-3xl font-bold tracking-tight text-slate-900">
          Administrator Dashboard
        </h1>
        <p class="text-slate-500">
          Manage users, jobs, and recruitment activity
        </p>
      </div>

      <!-- Error state -->
      <div
        v-if="error"
        class="mt-6 rounded-lg border border-red-200 bg-red-50 px-4 py-3 text-sm text-red-700"
      >
        {{ error }}
      </div>

      <!-- Loading state -->
      <div v-if="loading" class="mt-8 grid gap-6 md:grid-cols-3">
        <div
          v-for="i in 3"
          :key="i"
          class="h-28 animate-pulse rounded-xl border border-slate-200 bg-white"
        ></div>
      </div>

      <!-- Stats -->
      <div v-else class="mt-8 grid gap-6 md:grid-cols-3">
        <StatCard
          title="Total Users"
          :value="stats.totalUsers"
          accent="indigo"
        />
        <StatCard
          title="Active Jobs"
          :value="stats.totalJobs"
          accent="emerald"
        />
        <StatCard
          title="Applications"
          :value="stats.totalApplications"
          accent="amber"
        />
      </div>

      <!-- Overview + actions -->
      <div class="mt-8 grid gap-6 md:grid-cols-2">

        <div class="rounded-xl border border-slate-200 bg-white p-6 shadow-sm">
          <h2 class="mb-4 text-lg font-semibold text-slate-900">
            Recruitment Overview
          </h2>
          <div class="flex h-64 items-center justify-center rounded-lg bg-slate-50 text-sm text-slate-400">
            Chart area
          </div>
        </div>

        <div class="rounded-xl border border-slate-200 bg-white p-6 shadow-sm">
          <h2 class="mb-4 text-lg font-semibold text-slate-900">
            Quick Actions
          </h2>
          <div class="flex flex-col gap-3">
            <router-link
              to="/admin/users"
              class="rounded-lg bg-indigo-600 p-3 text-center font-medium text-white transition-colors hover:bg-indigo-700"
            >
              Manage Users
            </router-link>
            <router-link
              to="/admin/jobs"
              class="rounded-lg bg-emerald-600 p-3 text-center font-medium text-white transition-colors hover:bg-emerald-700"
            >
              Manage Jobs
            </router-link>
          </div>
        </div>

      </div>

    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import StatCard from "../../components/admin/StatCard.vue";
import { getDashboard } from "../../api/dashboard";

const stats = ref({
  totalUsers: 0,
  totalJobs: 0,
  totalApplications: 0,
});

const loading = ref(true);
const error = ref("");

const loadDashboard = async () => {
  try {
    const response = await getDashboard();
    stats.value = response.data;
  } catch (err) {
    console.error("Dashboard load failed:", err);
    error.value = "Unable to load dashboard";
  } finally {
    loading.value = false;
  }
};

onMounted(() => {
  loadDashboard();
});
</script>