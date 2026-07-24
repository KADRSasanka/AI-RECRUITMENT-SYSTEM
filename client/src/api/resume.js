import api from "./axios";

export const uploadResume = (formData) =>
    api.post("/Resume/upload", formData, {
        headers: {
            "Content-Type": "multipart/form-data"
        }
    });

export const getCandidateResumes = (candidateId) =>
    api.get(`/Resume/candidate/${candidateId}`);

export const deleteResume = (id) =>
    api.delete(`/Resume/${id}`);

export const downloadResume = (id) =>
    `http://localhost:5001/api/Resume/download/${id}`;