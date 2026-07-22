import api from "./axios";

export const getCandidates = () => api.get("/Candidate");

export const getCandidate = id => api.get(`/Candidate/${id}`);

export const createCandidate = data =>
    api.post("/Candidate", data);

export const updateCandidate = (id,data)=>
    api.put(`/Candidate/${id}`,data);

export const deleteCandidate=id=>
    api.delete(`/Candidate/${id}`);