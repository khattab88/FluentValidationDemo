using FluentValidation;

namespace API.Models
{
    public interface IUserManager
    {
        Task Manage(User user);
    }

    public class UserManager : IUserManager
    {
        private readonly IValidator<User> _validator;

        public UserManager(IValidator<User> validator)
        {
            _validator = validator;
        }

        public async Task Manage(User user)
        {
            var validationResult = await _validator.ValidateAsync(user);
            // await _validator.ValidateAndThrowAsync(user);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors) 
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                throw new Exception();
            }
        }
    }
}
