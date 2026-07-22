import {createRouter,createWebHistory}
from "vue-router";


import Login from "../views/Login.vue";


import {useAuthStore}
from "../stores/auth";


const routes=[


{
    path:"/",
    redirect:"/login"
},



{
    path:"/login",
    component:Login
},



{
    path:"/candidate",
    component:()=>import("../views/candidate/CandidateDashboard.vue"),
    meta:{
        role:"Candidate"
    }
},



{
    path:"/recruiter",
    component:()=>import("../views/recruiter/RecruiterDashboard.vue"),
    meta:{
        role:"Recruiter"
    }
},



{
    path:"/manager",
    component:()=>import("../views/manager/ManagerDashboard.vue"),
    meta:{
        role:"Hiring Manager"
    }
},



{
    path:"/admin",
    component:()=>import("../views/admin/AdminDashboard.vue"),
    meta:{
        role:"Administrator"
    }
}



];



const router=createRouter({

history:createWebHistory(),

routes

});




router.beforeEach((to)=>{


const auth=useAuthStore();


if(to.meta.role){


if(!auth.isAuthenticated)
{
return "/login";
}



if(auth.role!==to.meta.role)
{

return "/";

}


}



});



export default router;