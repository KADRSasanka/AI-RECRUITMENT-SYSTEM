import api from "./axios";

// Get all users
export const getUsers = () =>
    api.get("/User");

// Get user by ID
export const getUser = (id) =>
    api.get(`/User/${id}`);

// Create user
export const createUser = (data) =>
    api.post("/User", data);

// Update user
export const updateUser = (id, data) =>
    api.put(`/User/${id}`, data);

// Delete user
export const deleteUser = (id) =>
    api.delete(`/User/${id}`);