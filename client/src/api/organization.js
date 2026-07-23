import api from "./axios";

export const getOrganizations = () =>
    api.get("/Organization");