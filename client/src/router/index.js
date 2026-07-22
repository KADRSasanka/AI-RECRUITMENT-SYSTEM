import { createRouter, createWebHistory } from "vue-router";

import Login from "../views/auth/Login.vue";

import AdminDashboard from "../views/admin/Dashboard.vue";
import RecruiterDashboard from "../views/recruiter/Dashboard.vue";
import ManagerDashboard from "../views/manager/Dashboard.vue";
import CandidateDashboard from "../views/candidate/Dashboard.vue";

import NotFound from "../views/NotFound.vue";

import { useAuthStore } from "../stores/authStore";
import DashboardLayout from "../layouts/DashboardLayout.vue";

const routes = [
    {
        path:"/",
        component: DashboardLayout,

        children:[


            {
                path:"admin/dashboard",
                component:AdminDashboard
            },


            {
                path:"recruiter/dashboard",
                component:RecruiterDashboard
            },


            {
                path:"manager/dashboard",
                component:ManagerDashboard
            },


            {
                path:"candidate/dashboard",
                component:CandidateDashboard
            },


            {
                path: "/:pathMatch(.*)*",
                component: NotFound
            }

        ]

    }
    
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

router.beforeEach((to)=>{


    const auth = useAuthStore();



    const publicPages=[
        "/login"
    ];



    const authRequired =
        !publicPages.includes(to.path);



    if(authRequired && !auth.token){

        return "/login";

    }


});

export default router;