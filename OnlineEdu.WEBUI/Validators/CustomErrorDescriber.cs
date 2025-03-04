using Microsoft.AspNetCore.Identity;

namespace OnlineEdu.WEBUI.Validators
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Description = $"Bu {email} adresi zaten kullanılmaktadır."
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Description = $"Bu {userName} kullanıcı adı zaten kullanılmaktadır."
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Description = $"Şifre en az {length} karakter olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir rakam içermelidir."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir büyük harf içermelidir."
            };
        }

    }
}
