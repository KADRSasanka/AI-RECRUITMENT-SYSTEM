import api from "./axios";


export const analyzeCandidate = (
    candidateId,
    jobId
) => {

    return api.get(
        `/AI/candidate/${candidateId}/job/${jobId}`
    );

};