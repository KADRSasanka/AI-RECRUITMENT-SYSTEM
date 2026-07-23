import api from "./axios";

export const getDepartments = () =>
    api.get("/Department");