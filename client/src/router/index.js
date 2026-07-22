import { createRouter, createWebHistory } from "vue-router";

import Login from "../views/auth/Login.vue";
import DashboardLayout from "../layouts/DashboardLayout.vue";

import { useAuthStore } from "../stores/auth";

const routes = [

{
    path: "/",
    redirect: "/login"
},

{
    path: "/login",
    component: Login
},

// ==================== ADMIN ====================

{
    path: "/admin",
    component: DashboardLayout,
    meta: {
        role: "Administrator"
    },
    children: [

        {
            path: "dashboard",
            component: () =>
                import("../views/admin/Dashboard.vue")
        },

        {
            path: "users",
            component: () =>
                import("../views/admin/Users.vue")
        }

    ]
},

// ==================== RECRUITER ====================

{
    path: "/recruiter",
    component: DashboardLayout,
    meta: {
        role: "Recruiter"
    },
    children: [

        {
            path: "dashboard",
            component: () =>
                import("../views/recruiter/Dashboard.vue")
        }

    ]
},

// ==================== MANAGER ====================

{
    path: "/manager",
    component: DashboardLayout,
    meta: {
        role: "Hiring Manager"
    },
    children: [

        {
            path: "dashboard",
            component: () =>
                import("../views/manager/Dashboard.vue")
        }

    ]
},

// ==================== CANDIDATE ====================

{
    path: "/candidate",
    component: DashboardLayout,
    meta: {
        role: "Candidate"
    },
    children: [

        {
            path: "dashboard",
            component: () =>
                import("../views/candidate/Dashboard.vue")
        }

    ]
},





{
 path:"/admin/users",
 component:()=>import("../views/admin/Users.vue"),
 meta:{
    role:"Administrator"
 }
}

];

const router = createRouter({

    history: createWebHistory(),

    routes

});

router.beforeEach((to) => {

    const auth = useAuthStore();

    if (to.meta.role) {

        if (!auth.isAuthenticated) {
            return "/login";
        }

        if (auth.role !== to.meta.role) {
            return "/";
        }
    }
});

export default router;