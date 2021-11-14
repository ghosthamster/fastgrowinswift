using AutoMapper;
using EasyCSharpApi.DAL;
using EasyCSharpApi.DTOs;
using EasyCSharpApi.Services.Abstractions;
using EasyCSharpApi.UnitOfWork.Abstraction;

using System.Collections.Generic;
using System.Linq;

namespace EasyCSharpApi.Services
{
    public class TaskService : ITaskService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int CreateTask(TaskDTO task)
        {
            var mappedTask = _mapper.Map<TaskDTO, Task>(task);

            var newTask = _unitOfWork.TaskRepository.Add(mappedTask);
            _unitOfWork.Save();

            return newTask.Id;
        }

        public int CreateTitle(TitleDTO title)
        {
            var mappedTitle = _mapper.Map<TitleDTO, Title>(title);
            var newId = _unitOfWork.TaskRepository.CreateTitle(mappedTitle);
            _unitOfWork.Save();
            var crutch = _unitOfWork.TaskRepository.GetAllTitles().OrderByDescending(x=>x.Id).FirstOrDefault();
            return crutch.Id;
        }

        public int CreateType(TypeDTO type)
        {
            var mappedType = _mapper.Map<TypeDTO, Type>(type);
            var newId = _unitOfWork.TaskRepository.CreateType(mappedType);
            _unitOfWork.Save();

            return newId;
        }

        public List<TitleDTO> GetAllTitles()
        {
            var list = _unitOfWork.TaskRepository.GetAllTitles();
            var mappedList = _mapper.Map<List<Title>, List<TitleDTO>>(list);

            return mappedList;
        }

        public List<TypeDTO> GetAllTypes()
        {
            var list = _unitOfWork.TaskRepository.GetAllTypes();
            var mappedList = _mapper.Map<List<Type>, List<TypeDTO>>(list);

            return mappedList;
        }

        public List<TaskDTO> GetTaskByTitleId(int titleId, int take, int skip)
        {
            var tasks = _unitOfWork.TaskRepository.GetTaskByTitleId(titleId, take, skip);
            var mappedTasks = _mapper.Map<List<Task>, List<TaskDTO>>(tasks);
            return mappedTasks;
        }
    }
}
