import api from "./axios";

export const getCandidates = () => api.get("/Candidate");

export const getCandidate = id => api.get(`/Candidate/${id}`);

export const createCandidate = data =>
    api.post("/Candidate", data);

export const updateCandidate = (id,data)=>
    api.put(`/Candidate/${id}`,data);

export const deleteCandidate=id=>
<<<<<<< HEAD
    api.delete(`/Candidate/${id}`);export const getCandidateDashboard = () =>
    api.get("/Candidate/dashboard");
=======
    api.delete(`/Candidate/${id}`);
>>>>>>> 8f9a0d3bd98dbda438bedc965666c7ed17e6bd2d

export const getCandidateDashboard = () =>
    api.get("/Candidate/dashboard");