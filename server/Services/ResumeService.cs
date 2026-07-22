using server.DTOs.Resume;
using server.Entities;
using server.Interfaces;

namespace server.Services;


public class ResumeService : IResumeService
{

    private readonly IResumeRepository _repository;


    private readonly string _uploadPath =
        Path.Combine(
            Directory.GetCurrentDirectory(),
            "Uploads",
            "Resumes"
        );



    public ResumeService(
        IResumeRepository repository)
    {
        _repository = repository;


        if(!Directory.Exists(_uploadPath))
        {
            Directory.CreateDirectory(_uploadPath);
        }
    }



    public async Task<ResumeResponseDto> UploadAsync(
        UploadResumeDto dto)
    {


        if(dto.Resume == null)
            throw new Exception("Resume file required.");



        if(dto.Resume.ContentType != 
            "application/pdf")
        {
            throw new Exception(
                "Only PDF files are allowed.");
        }



        if(dto.Resume.Length > 5 * 1024 * 1024)
        {
            throw new Exception(
                "Maximum file size is 5MB.");
        }



        var extension =
            Path.GetExtension(
                dto.Resume.FileName);



        var storedName =
            Guid.NewGuid()
            .ToString()
            + extension;



        var filePath =
            Path.Combine(
                _uploadPath,
                storedName);



        using(var stream =
            new FileStream(
                filePath,
                FileMode.Create))
        {
            await dto.Resume
                .CopyToAsync(stream);
        }



        var resume = new Resume
        {
            CandidateId = dto.CandidateId,

            FileName = dto.Resume.FileName,

            StoredFileName = storedName,

            FilePath = filePath,

            FileSize = dto.Resume.Length,

            ContentType =
                dto.Resume.ContentType,

            UploadedAt =
                DateTime.UtcNow
        };



        await _repository.AddAsync(resume);



        return new ResumeResponseDto
        {
            ResumeId = resume.ResumeId,

            FileName = resume.FileName,

            FileSize = resume.FileSize,

            UploadedAt = resume.UploadedAt
        };
    }




    public async Task<IEnumerable<ResumeResponseDto>>
        GetByCandidateIdAsync(int candidateId)
    {

        var resumes =
            await _repository
            .GetByCandidateIdAsync(candidateId);



        return resumes.Select(r =>
            new ResumeResponseDto
            {
                ResumeId = r.ResumeId,

                FileName = r.FileName,

                FileSize = r.FileSize,

                UploadedAt = r.UploadedAt
            });
    }





    public async Task<bool> DeleteAsync(int id)
    {

        var resume =
            await _repository
            .GetByIdAsync(id);



        if(resume == null)
            return false;



        if(File.Exists(resume.FilePath))
        {
            File.Delete(resume.FilePath);
        }



        await _repository.DeleteAsync(resume);


        return true;
    }

}