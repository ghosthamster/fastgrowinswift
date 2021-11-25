using AutoMapper;
using EasyCSharpApi.DAL;
using EasyCSharpApi.DTOs;
using EasyCSharpApi.Services.Abstractions;
using EasyCSharpApi.UnitOfWork.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace EasyCSharpApi.Services
{
    public class ProgressService : IProgressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int CreateProgress(ProgressDTO progressDTO)
        {
            var savedProgress = new Progress();

            if (progressDTO.Id != 0)
            {
                {
                    var progress = _mapper.Map<Progress>(progressDTO);
                    _unitOfWork.ProgressRepository.Delete(progressDTO.Id);
                    _unitOfWork.Save();
                    progress.Id = 0;
                    _unitOfWork.ProgressRepository.Add(progress);
                    //savedProgress = _unitOfWork.ProgressRepository.Edit(progress);
                }
            }
            else
            {
                var progress = _mapper.Map<Progress>(progressDTO);
                savedProgress = _unitOfWork.ProgressRepository.Add(progress);
            }

            _unitOfWork.Save();

            return savedProgress.Id;
        }

        public void DeleteProgress(int userId, int taskId)
        {
            var progress = GetProgressByTaskIdAndUserId(taskId, userId);
            if (progress != null)
            {
                _unitOfWork.ProgressRepository.Delete(progress.Id);
                _unitOfWork.Save();
            }
        }

        public List<ProgressDTO> GetAllUserProgresses(int userId)
        {
            var userProgresses = _unitOfWork.ProgressRepository.GetAllByUserId(userId).ToList();
            var userProgressesDTO = _mapper.Map<List<ProgressDTO>>(userProgresses);

            foreach (var progress in userProgresses)
            {
                DeleteProgress(userId, progress.TaskId);
            }

            return userProgressesDTO;
        }

        public ProgressDTO GetProgressByTaskIdAndUserId(int taskId, int userId)
        {
            var userProgresses = _unitOfWork.ProgressRepository.GetAllByUserId(userId).FirstOrDefault(p => p.TaskId == taskId);
            var userProgressesDTO = _mapper.Map<ProgressDTO>(userProgresses);

            return userProgressesDTO;
        }

        public ProgressDTO UpdateProgress(ProgressDTO progressDTO)
        {
            var progress = _mapper.Map<Progress>(progressDTO);
            var updatedProgress = _unitOfWork.ProgressRepository.Edit(progress);
            _unitOfWork.Save();

            var updatedProgressDTO = _mapper.Map<ProgressDTO>(updatedProgress);

            return updatedProgressDTO;
        }
    }
}
