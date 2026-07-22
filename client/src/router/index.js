import { createRouter, createWebHistory } from "vue-router";

import Login from "../views/auth/Login.vue";

import DashboardLayout from "../layouts/DashboardLayout.vue";

import { useAuthStore } from "../stores/auth";


const routes = [


{
    path:"/",
    redirect:"/login"
},



{
    path:"/login",
    component:Login
},



{
    path:"/",
    component:DashboardLayout,

    children:[


        {
            path:"candidate",
            component:()=>import("../views/candidate/Dashboard.vue"),

            meta:{
                role:"Candidate"
            }
        },



        {
            path:"recruiter",
            component:()=>import("../views/recruiter/Dashboard.vue"),

            meta:{
                role:"Recruiter"
            }
        },



        {
            path:"manager",
            component:()=>import("../views/manager/Dashboard.vue"),

            meta:{
                role:"Hiring Manager"
            }
        },



        {
            path:"admin/dashboard",
            component:()=>import("../views/admin/Dashboard.vue"),

            meta:{
                role:"Administrator"
            }
        }


    ]

}


];




const router=createRouter({

    history:createWebHistory(),

    routes

});





router.beforeEach((to)=>{


    const auth = useAuthStore();



    if(to.meta.role){



        if(!auth.isAuthenticated)
        {
            return "/login";
        }




        if(auth.role !== to.meta.role)
        {
            return "/";
        }


    }



});




export default router;