import api from "./axios";

// Get all interviews
export const getInterviews = () =>
    api.get("/Interview");

// Get interview by ID
export const getInterview = (id) =>
    api.get(`/Interview/${id}`);

// Create interview
export const createInterview = (data) =>
    api.post("/Interview", data);

// Update interview
export const updateInterview = (id, data) =>
    api.put(`/Interview/${id}`, data);

// Delete interview
export const deleteInterview = (id) =>
    api.delete(`/Interview/${id}`);