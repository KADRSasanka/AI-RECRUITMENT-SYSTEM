import api from "./axios";

// Get all jobs
export const getJobs = () =>
    api.get("/Job");

// Get job by ID
export const getJob = (id) =>
    api.get(`/Job/${id}`);

// Create new job
export const createJob = (data) =>
    api.post("/Job", data);

// Update job
export const updateJob = (id, data) =>
    api.put(`/Job/${id}`, data);

// Delete job
export const deleteJob = (id) =>
    api.delete(`/Job/${id}`);