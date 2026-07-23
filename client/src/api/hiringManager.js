import api from "./axios";


// Assigned jobs
export const getManagerJobs = () =>
    api.get("/HiringManager/jobs");


// Applications for review
export const getManagerApplications = () =>
    api.get("/HiringManager/applications");


// Interviews
export const getManagerInterviews = () =>
    api.get("/HiringManager/interviews");