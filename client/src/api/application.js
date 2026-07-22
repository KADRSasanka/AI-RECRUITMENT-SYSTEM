import api from "./axios";

// Get all applications
export const getApplications = () =>
    api.get("/Application");

// Get application by ID
export const getApplication = (id) =>
    api.get(`/Application/${id}`);

// Get applications by candidate
export const getApplicationsByCandidate = (candidateId) =>
    api.get(`/Application/candidate/${candidateId}`);

// Get applications by job
export const getApplicationsByJob = (jobId) =>
    api.get(`/Application/job/${jobId}`);

// Create application
export const createApplication = (data) =>
    api.post("/Application", data);

// Update application
export const updateApplication = (id, data) =>
    api.put(`/Application/${id}`, data);