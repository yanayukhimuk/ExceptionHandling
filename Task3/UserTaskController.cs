using Task3.DoNotChange;
using System;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = GetMessageForModel(userId, description);
            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            return true;
        }

        private string GetMessageForModel(int userId, string description)
        {
            string message = null;
            try
            {
                var task = new UserTask(description);
                int result = _taskService.AddTaskForUser(userId, task);
            }
            catch (ArgumentOutOfRangeException)
            {
                message = "Invalid userId";
            }
            catch (NullReferenceException)
            {
                message = "User not found";
            }
            catch (ArgumentException)
            {
                message = "The task already exists";
            }

            return message;
        }
    }
}