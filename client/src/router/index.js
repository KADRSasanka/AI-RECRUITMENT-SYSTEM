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
            path:"dashboard",
            component:()=>import("../views/recruiter/Dashboard.vue")
        },

        {
            path:"jobs",
            component:()=>import("../views/recruiter/Jobs.vue")
        },

        {
            path:"jobs/create",
            component:()=>import("../views/recruiter/CreateJob.vue")
        },

        {
            path:"jobs/edit/:id",
            component:()=>import("../views/recruiter/EditJob.vue")
        },
        {
            path:"/recruiter/jobs/:id/applications",

            component:()=>import("../views/recruiter/Applicants.vue"),

            meta:{
                role:"Recruiter"
            }

        },
        {
            path:"/recruiter/application/:id",

            component:()=>import("../views/recruiter/ApplicationReview.vue"),

            meta:{
                role:"Recruiter"
            }
        },
        {
            path:"/recruiter/applications",
            component:()=>import(
                "../views/recruiter/Applicants.vue"
            ),
            meta:{
                role:"Recruiter"
            }
        },
        {
            path: "/recruiter/interviews",
            component: () => import("../views/interview/InterviewList.vue"),
            meta:{
                role:"Recruiter"
            }
        },
        {
            path: "/recruiter/interviews/create",
            component: () => import("../views/interview/CreateInterview.vue"),
            meta:{
                role:"Recruiter"
            }
        },
        {
            path: "/recruiter/interviews/:id/edit",
            component: () => import("../views/interview/EditInterview.vue"),
            meta:{
                role:"Recruiter"
            }
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